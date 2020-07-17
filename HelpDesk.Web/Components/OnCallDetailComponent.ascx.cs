// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallDetailComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the OnCallDetailComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.Collections.Generic;

    using HelpDesk.Models;

    /// <summary>
    /// The on call detail component.
    /// </summary>
    public partial class OnCallDetailComponent : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public OnCallModel Model
        {
            get
            {
                return (OnCallModel)this.ViewState[nameof(this.Model)];
            }

            set
            {
                this.ViewState[nameof(this.Model)] = value;
            }
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <returns>
        /// The <see cref="OnCallModel"/>.
        /// </returns>
        public OnCallModel Select()
        {
            return this.Model;
        }

        /// <summary>
        /// The select on call report list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{OnCallReportModel}"/>.
        /// </returns>
        public IEnumerable<OnCallReportModel> SelectOnCallReportList()
        {
            return this.Model.ProcessDetails;
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
            // Ignore
        }
    }
}