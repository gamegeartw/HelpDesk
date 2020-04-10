// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ADUserManager.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the ADUserManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Admins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

    using Landpy.ActiveDirectory.Core;
    using Landpy.ActiveDirectory.Entity.Object;

    using NLog;

    /// <summary>
    /// The ad user manager.
    /// </summary>
    public partial class ADUserManager : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
        /// The service.
        /// </summary>
        private ADService Service => new ADService(WebUtils.GetAdOperator());

        /// <summary>
        /// The detail.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        public void Detail(string account)
        {
            this.Response.Redirect(
                this.Page.ResolveClientUrl($"~/Admins/UserDetail.aspx?account={account}&type=AD"),
                true);
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
        /// The select users.
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
        /// The <see cref="IEnumerable{ADUserViewModel}"/>.
        /// </returns>
        public IEnumerable<UserObject> SelectUsers(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = 0;
            try
            {
                var users = this.Service.GetAll();
                if (this.SearchViewModel != null)
                {
                    users = users.Where(
                        m => 
                            m.SAMAccountName.ToLower().Contains(
                                 this.SearchViewModel.SearchText)
                             || m.DisplayName.ToLower().Contains(
                                 this.SearchViewModel.SearchText) 
                             || m.Email.ToLower().Contains(
                                 this.SearchViewModel.SearchText) 
                             || m.Telephone.Contains(
                                 this.SearchViewModel.SearchText))
                        .ToList();
                }

                totalRowCount = users.Count;
                return users.Skip(startRowIndex).Take(maximumRows);
            }
            catch (Exception e)
            {
                if (this.Service.HandleException != null)
                {
                    e = this.Service.HandleException;
                }

                Logger.Error(e);
                this.Page.ModelState.AddModelError("Select", e.Message);
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
            try
            {
                if (e.CommandName == "Detail")
                {
                    this.Response.Redirect(
                        this.Page.ResolveClientUrl($"~/Admins/UserDetail.aspx?account={e.CommandArgument}&type=AD"),
                        true);
                    return;
                }

                var @type = this.Service.GetType();
                var method = @type.GetMethod(e.CommandName);
                if (method != null)
                {
                    var exception = (Exception)method.Invoke(this.Service, new[] { e.CommandArgument });
                    if (exception != null)
                    {
                        throw exception;
                    }
                }

                WebUtils.ShowAjaxMessage(this.Page, "作業已完成");
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                this.Page.ModelState.AddModelError(e.CommandName, exception.Message);
            }

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
                this.MetaDescription = "AD用戶管理";
            }
        }
    }
}