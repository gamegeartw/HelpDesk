// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the StatusComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;

    using HelpDesk.Enums;

    using NLog;

    public partial class StatusComponent : System.Web.UI.UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the help desk status.
        /// </summary>
        public string HelpDeskStatus
        {
            get
            {
                return (string)this.ViewState[nameof(this.HelpDeskStatus)];
            }
            set
            {
                this.ViewState[nameof(this.HelpDeskStatus)] = value;
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

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            this.Literal1.Text = ((ProcessStatus)Enum.Parse(typeof(ProcessStatus), this.HelpDeskStatus)).DisplayName();
        }

        // public IEnumerable<KeyValuePair<string,string>> Select([ViewState(nameof(HelpDeskStatus))]string status)
        // {
        //     var items = new List<KeyValuePair<string, string>>();
        //     var value = ((ProcessStatus)Enum.Parse(
        //                         typeof(ProcessStatus),
        //                         this.HelpDeskStatus)).DisplayName();
        //     items.Add(new KeyValuePair<string, string>(value, value));
        //     return items;
        // }
    }
}