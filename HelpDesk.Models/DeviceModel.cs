// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceModel.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   The device model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;

    /// <summary>
    /// The device model.
    /// </summary>
    [Serializable]
    public class DeviceModel
    {
        /// <summary>
        /// Gets or sets the no.
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public decimal Count { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the import time.
        /// </summary>
        public DateTime? ImportTime { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
