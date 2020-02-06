// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DevicesManatain.aspx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the DevicesManatain type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.UserPages
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.ModelBinding;

    using HelpDesk.Services;
    using HelpDesk.ViewModels;

    /// <summary>
    /// The devices manatain.
    /// </summary>
    public partial class DevicesManatain : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the search view model.
        /// </summary>
        public FormSearchViewModel SearchViewModel
        {
            get
            {
                return this.ViewState[nameof(this.SearchViewModel)] as FormSearchViewModel;
            }

            set
            {
                this.ViewState[nameof(this.SearchViewModel)] = value;
            }
        }

        /// <summary>
        /// Gets or sets the service device.
        /// </summary>
        private Services.DeviceService ServiceDevice =>new DeviceService();


        public DevicesManatain()
        {
        }

        public override void Dispose()
        {
            this.ServiceDevice.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        public void Delete()
        {
            if (this.ModelState.IsValid)
            {
            }
        }

        /// <summary>
        /// The insert.
        /// </summary>
        public void Insert()
        {
            if (this.ModelState.IsValid)
            {
            }
        }

        /// <summary>
        /// The select.
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
        /// The <see cref="IEnumerable{DeviceViewModel}"/>.
        /// </returns>
        public IEnumerable<DeviceViewModel> Select(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = 0;
            this.SearchViewModel.StartRowIndex = startRowIndex;
            this.SearchViewModel.MaximumRows = maximumRows;
            return null;
        }

        /// <summary>
        /// The select item.
        /// </summary>
        /// <param name="no">
        /// The no.
        /// </param>
        /// <returns>
        /// The <see cref="DeviceViewModel"/>.
        /// </returns>
        public DeviceViewModel SelectItem([Control("ListView", "SelectedValue")] string no)
        {
            return null;
        }

        public void Update()
        {
            if (this.ModelState.IsValid)
            {
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
        }
    }
}