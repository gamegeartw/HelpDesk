// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallList.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the OnCallList type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

    using Microsoft.Ajax.Utilities;

    using NLog;

    /// <summary>
    /// The on call list.
    /// </summary>
    public partial class OnCallList : System.Web.UI.Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The service.
        /// </summary>
        private readonly OnCallService service = new OnCallService(new SqlConnection(WebUtils.GetConnString("Intranet_DB_Write")));

        /// <summary>
        /// Gets or sets the search view model.
        /// </summary>
        public FormSearchViewModel SearchViewModel
        {
            get
            {
                return (FormSearchViewModel)this.ViewState[nameof(this.SearchViewModel)];
            }

            set
            {
                this.ViewState[nameof(this.SearchViewModel)] = value;
            }
        }

        public override void Dispose()
        {
            this.service?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The select value.
        /// </summary>
        /// <param name="startRowIndex">
        /// The start Row Index.
        /// </param>
        /// <param name="maximumRows">
        /// The maximum Rows.
        /// </param>
        /// <param name="totalRowCount">
        /// The total Row Count.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{ServiceOnCallViewModel}"/>.
        /// </returns>
        public IEnumerable<OnCallModel> SelectValue(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = 0;
            try
            {
                var searchModel = new FormSearchViewModel
                                      {
                                          MaximumRows = maximumRows, 
                                          StartRowIndex = startRowIndex
                                      };
                var result = this.service.GetList(searchModel);
                if (result.Count > 0)
                {
                    totalRowCount = result.First().TotalRowCount;
                }
                
                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("select", e.Message);
            }

            return null;
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
            this.ListViewMain.DataBind();
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
                this.MetaDescription = "報修清單";
            }
        }

        /// <summary>
        /// The list view main_ on item command.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ListViewMain_OnItemCommand(object sender, ListViewCommandEventArgs e)
        {
            var p = this.GetType();
            if (e.CommandArgument != null)
            {
                try
                {
                    var method = p.GetMethod(e.CommandName);
                    if (method != null)
                    {
                        method.Invoke(this, new[] { e.CommandArgument });
                    }
                }
                catch (Exception exception)
                {
                    Logger.Error(exception);
                    this.ModelState.AddModelError("error", exception.Message);
                }
            }
        }

        /// <summary>
        /// 結案作業(名稱要跟CommandName一樣)
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        // ReSharper disable once StyleCop.SA1202
        public void CloseReport(string id)
        {
            try
            {
                this.service.CloseReport(id);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                this.ModelState.AddModelError("error", exception.Message);
            }
        }
    }
}