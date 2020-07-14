// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallDetail.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The on call detail.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using HelpDesk.Enums;
    using HelpDesk.Models;
    using HelpDesk.Services;
    using HelpDesk.Utils;

    /// <summary>
    /// The on call detail.
    /// </summary>
    public partial class OnCallDetail : Page
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly OnCallService ServiceOnCall;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCallDetail"/> class.
        /// </summary>
        public OnCallDetail()
        {
            this.ServiceOnCall = new OnCallService(new SqlConnection(WebUtils.GetConnString("Intranet_DB")));
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
            if (!this.IsPostBack)
            {

            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.ServiceOnCall?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="docNo">
        /// The doc No.
        /// </param>
        /// <returns>
        /// The <see cref="OnCallModel"/>.
        /// </returns>
        public OnCallModel Select([QueryString("DocNo")] string docNo)
        {
            if (string.IsNullOrWhiteSpace(docNo))
            {
                this.ModelState.AddModelError(nameof(docNo), "沒有單據號碼(Null)");
                return null;
            }

            var result = this.ServiceOnCall.GetByDocNo(docNo);

            if (result == null)
            {
                this.ModelState.AddModelError(nameof(docNo), "單據號碼錯誤(Error docNo)");
                return null;
            }

            if (result.ProcessStatus == ProcessStatus.Finish)
            {
                this.ModelState.AddModelError(nameof(docNo), "單據已結案(Case is close)");
            }

            return result;
        }

        public IEnumerable<OnCallReportModel> SelectReportModels([QueryString("DocNo")] string docNo)
        {
            return null;

            // throw new NotImplementedException();
        }
    }
}