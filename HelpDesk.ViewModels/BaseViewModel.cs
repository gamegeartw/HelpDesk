using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.ViewModels
{
    /// <summary>
    /// The base view model.
    /// </summary>
    [Serializable]
    public class BaseViewModel
    {
        /// <summary>
        /// Gets or sets the start row index.
        /// </summary>
        public int StartRowIndex { get; set; } = 0;

        /// <summary>
        /// Gets or sets the maximum rows.
        /// </summary>
        public int MaximumRows { get; set; } = 1000;

        /// <summary>
        /// Gets or sets the total row count.
        /// </summary>
        public int TotalRowCount { get; set; }
    }
}
