// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpDeskEventArgs.cs" company="">
//   
// </copyright>
// <summary>
//   The help desk event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Events
{
    using System;

    /// <summary>
    /// The help desk event args.
    /// </summary>
    /// <typeparam name="T">
    /// Objects
    /// </typeparam>
    public class HelpDeskEventArgs<T> : EventArgs
        where T : class, new()
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }
    }
}