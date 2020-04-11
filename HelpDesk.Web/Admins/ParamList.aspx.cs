// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParamList.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The param list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Admins
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

    using NLog;

    /// <summary>
    /// The param list.
    /// </summary>
    public partial class ParamList : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        private ParamsService Service { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParamList"/> class.
        /// </summary>
        public ParamList()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = WebUtils.GetConnString("Intranet_DB_Write");
            this.Service = new ParamsService(conn);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.Service?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// Gets or sets the search view model.
        /// </summary>
        public FormSearchViewModel SearchViewModel
        {
            get
            {
                if (this.ViewState[nameof(this.SearchViewModel)] != null)
                {
                    return (FormSearchViewModel)this.ViewState[nameof(this.SearchViewModel)];
                }

                return null;
            }

            set
            {
                this.ViewState[nameof(this.SearchViewModel)] = value;
            }
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.MetaDescription = "系統參數管理";
            }
        }

        /// <summary>
        /// The form search component_ on search.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void FormSearchComponent_OnSearch(object sender, HelpDeskEventArgs<FormSearchViewModel> e)
        {
            this.SearchViewModel = e.Data;
        }

        /// <summary>
        /// The select list.
        /// </summary>
        /// <param name="startRowIndex">
        /// The start row index.
        /// </param>
        /// <param name="maximumRows">
        /// The maximum rows.
        /// </param>
        /// <param name="totalRowCount">
        /// The total row count.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ParamData> SelectList(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = 0;
            try
            {
                if (this.SearchViewModel == null)
                {
                    this.SearchViewModel = new FormSearchViewModel();
                }

                var result = this.Service.GetList(this.SearchViewModel).ToList();
                if (result.Any())
                {
                    totalRowCount = result.Count();
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("Select", e.Message);
            }

            return null;
        }

        /// <summary>
        /// The insert data.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void InsertData(ParamData value)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    this.Service.Insert(value);
                    WebUtils.ShowAjaxMessage(this.Page,"作業成功");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("Insert", e.Message);
            }
        }

        /// <summary>
        /// The update data.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void UpdateData(ParamData value)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var sourceData = this.Service.Get(value.Id);
                    this.TryUpdateModel(sourceData);
                    this.Service.Update(sourceData);
                    WebUtils.ShowAjaxMessage(this.Page,"作業成功");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("Update", e.Message);
            }
        }

        public void DeleteData(ParamData value)
        {
            try
            {
                this.Service.Delete(value.Id);
                WebUtils.ShowAjaxMessage(this.Page,"作業成功");
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("Delete", e.Message);
            }
        }

        protected void ListViewMain_OnItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            this.ListViewMain.DataBind();
        }

        protected void ListViewMain_OnItemUpdated(object sender, ListViewUpdatedEventArgs e)
        {
            this.ListViewMain.DataBind();
        }

        protected void ListViewMain_OnItemDeleted(object sender, ListViewDeletedEventArgs e)
        {
            this.ListViewMain.DataBind();
        }
    }
}