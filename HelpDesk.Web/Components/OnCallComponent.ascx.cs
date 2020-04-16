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
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;

    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;

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
        /// The service.
        /// </summary>
        private Services.ParamsService Service { get; set; }


        public OnCallComponent()
        {
            this.Service = new ParamsService(new SqlConnection(WebUtils.GetConnString("Intranet_DB")));
        }

        public override void Dispose()
        {
            this.Service?.Dispose();
            base.Dispose();
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

        public IEnumerable SelectList()
        {
            try
            {
                this.Service.GetList("OnCall");
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("OnCall", e.Message);
            }

            return null;
        }
    }
}