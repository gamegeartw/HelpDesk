// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The on call component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Services;
    using HelpDesk.Utils;

    using NLog;

    /// <summary>
    /// The on call component.
    /// </summary>
    public partial class OnCallComponent : UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCallComponent"/> class.
        /// </summary>
        public OnCallComponent()
        {
            this.Service = new ParamsService(new SqlConnection(WebUtils.GetConnString("Intranet_DB")));
        }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        public string DefaultValue
        {
            get
            {
                return this.DropDownListMain.SelectedValue;
            }

            set
            {
                this.DropDownListMain.SelectedValue = value;
            }
        }

        /// <summary>
        /// The service.
        /// </summary>
        private ParamsService Service { get; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.Service?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The select list.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{KeyValuePair}"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> SelectList()
        {
            var result = new List<KeyValuePair<string, string>>();
            try
            {
                var list = this.Service.GetList("OnCall");
                foreach (var data in list)
                {
                    result.Add(new KeyValuePair<string, string>($"{data.Data}-{data.Key}", data.Data));
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("OnCall", e.Message);
            }

            return result;
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

        protected void DropDownListMain_OnDataBound(object sender, EventArgs e)
        {
            foreach (var listItem in this.DropDownListMain.Items.OfType<ListItem>())
            {
                listItem.Selected = listItem.Value == "M4";
            }
        }
    }
}