using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelpDesk.Events
{
    /// <summary>
    /// The help desk event arg.
    /// </summary>
    /// <typeparam name="T">
    /// T is object
    /// </typeparam>
    public class HelpDeskEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets or sets the extra obj.
        /// </summary>
        public T ExtraObj { get; set; }
    }
}