// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the _Default type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

    using Landpy.ActiveDirectory.Entity.Object;

    using NLog;

    /// <summary>
    /// The _ default.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public partial class _Default : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The service.
        /// </summary>
        private readonly ADService service = new ADService(WebUtils.GetAdOperator());

        /// <summary>
        /// Gets or sets the search view model.
        /// </summary>
        private FormSearchViewModel SearchViewModel
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

        /// <summary>
        /// The dispose.
        /// </summary>
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
        /// The <see cref="IEnumerable{UserObject}"/>.
        /// </returns>
        public IEnumerable<UserObject> SelectValue(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = 0;
            try
            {
                var users = 
                    this.service.GetAll().OrderBy(m => m.Telephone).Where(m => m.IsEnabled)
                        .Where(m => !string.IsNullOrWhiteSpace(m.Telephone));
                
                if (this.SearchViewModel != null)
                {
                    this.SearchViewModel.SearchText = this.SearchViewModel.SearchText.ToLower().Trim();
                    users = users
                        .Where(
                        m => m.SAMAccountName.ToLower().Contains(this.SearchViewModel.SearchText)
                             || m.DisplayName.ToLower().Contains(this.SearchViewModel.SearchText)
                             || m.Email.ToLower().Contains(this.SearchViewModel.SearchText)
                             || m.Department.ToLower().Contains(this.SearchViewModel.SearchText)
                             || m.Telephone.ToLower().Contains(this.SearchViewModel.SearchText));
                }

                totalRowCount = users.Count();

                return users.Skip(startRowIndex).Take(maximumRows);
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("Search", e.Message);
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
                this.MetaDescription = "首頁";
            }
        }
    }
}