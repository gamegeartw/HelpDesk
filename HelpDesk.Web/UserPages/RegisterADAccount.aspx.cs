// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterADAccount.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The register ad account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Enums;

    using Landpy.ActiveDirectory.Core;

    using NLog;

    /// <summary>
    /// The register ad account.
    /// </summary>
    public partial class RegisterADAccount : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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

        }

        protected void OnItemCommand(object sender, FormViewCommandEventArgs e)
        {
            
        }

        /// <summary>
        /// The insert value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void InsertValue(ViewModels.ADUserViewModel value)
        {

        }

        /// <summary>
        /// The on item inserting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void OnItemInserting(object sender, FormViewInsertEventArgs e)
        {
            if (string.IsNullOrWhiteSpace((string)e.Values["ExtNumber"]))
            {
                this.ModelState.AddModelError("ExtNumber", "連絡電話不得為空");
            }

            if (string.IsNullOrWhiteSpace((string)e.Values["EmpNo"]))
            {
                this.ModelState.AddModelError("EmpNo", "工號不得為空");
            }
        }
    }
}