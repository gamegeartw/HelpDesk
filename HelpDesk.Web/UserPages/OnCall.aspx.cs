// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCall.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   叫修頁面
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Web.UI;

    using HelpDesk.Utils;
    using HelpDesk.ViewModels;
    using HelpDesk.Web.Components;

    using NLog;

    /// <summary>
    /// 叫修頁面
    /// </summary>
    public partial class OnCall : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.MetaDescription = "叫修作業";
            }
        }

        public void InsertValue(ServiceOnCallViewModel value)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    WebUtils.ShowAjaxMessage(this.Page, "作業成功");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("error", e.Message);
            }
        }

        protected void FormViewMain_OnItemCreated(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                var uc = (UsersComponent)this.FormViewMain.FindControl("UsersComponent");
                uc.DefaultValues = User.Identity.Name;
            }
        }
    }
}