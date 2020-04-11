// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseClass.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   The base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;

    /// <summary>
    /// The base class.
    /// </summary>
    [Serializable]
    public class BaseClass
    {
        /// <summary>
        /// Gets or sets the start row index.
        /// </summary>
        public int TotalRowCount { get; set; }

        /// <summary>
        /// Gets or sets the start row index.
        /// </summary>
        public int StartRowIndex { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum rows.
        /// </summary>
        public int MaximumRows { get; set; } = 1000;
    }
}
