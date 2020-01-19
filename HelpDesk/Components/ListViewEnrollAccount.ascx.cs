// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListViewEnrollAccount.ascx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   The list view enroll account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// The list view enroll account.
    /// </summary>
    public partial class ListViewEnrollAccount : UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly NLog.Logger Logger = 
            NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets a value indicating whether manager mode.
        /// </summary>
        public bool ManagerMode
        {
            get
            {
                if (this.ViewState[nameof(this.ManagerMode)] == null)
                {
                    return false;
                }

                return (bool)this.ViewState[nameof(this.ManagerMode)];
            }

            set
            {
                this.ViewState[nameof(this.ManagerMode)] = value;
            }
        }

        /// <summary>
        /// The select list.
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ViewModels.AccountEnrollViewModel> SelectList(
            int startRowIndex,
            int maximumRows,
            out int totalRowCount)
        {
            totalRowCount = 0;
            try
            {
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError(e.Source, e.Message);
            }

            return null;
        }

        /// <summary>
        /// The update list.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void UpdateList(ViewModels.AccountEnrollViewModel model)
        {
            if (this.Page.ModelState.IsValid)
            {
                try
                {
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                    this.Page.ModelState.AddModelError(
                        e.Source,
                        e.Message);
                }
            }
        }

        /// <summary>
        /// The list view main_ on item data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ListViewMain_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var labelEx = e.Item.FindControl("LabelStatusEx") as LabelStatusEx;
            if (labelEx != null)
            {
                labelEx.StatusEnum = 
                    ((ViewModels.AccountEnrollViewModel)e.Item.DataItem).Status;
            }

            if (this.ManagerMode)
            {
                var btns = e.Item.FindControl("PanelBtns");
                if (btns != null)
                {
                    btns.Visible = true;
                }
            }
        }
    }
}