// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelStatusEx.ascx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the LabelStatusEx type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Components
{
    using System;
    using System.Web.UI;

    using HelpDesk.Enums;

    /// <summary>
    /// The label status ex.
    /// </summary>
    public partial class LabelStatusEx : UserControl
    {
        /// <summary>
        /// Gets or sets the status enum.
        /// </summary>
        public Status StatusEnum
        {
            get
            {
                return (Status)this.ViewState[nameof(this.StatusEnum)];
            }

            set
            {
                this.ViewState[nameof(this.StatusEnum)] = value;
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
        public void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LiteralStatus.Text = this.StatusEnum.DisplayName();
            }
        }
    }
}