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

    using HelpDesk.ViewModels;
    using HelpDesk.Web.Events;

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

        /// <summary>
        /// The select value.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ServiceOnCallViewModel}"/>.
        /// </returns>
        public IEnumerable<ServiceOnCallViewModel> SelectValue()
        {
            try
            {
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
    }
}