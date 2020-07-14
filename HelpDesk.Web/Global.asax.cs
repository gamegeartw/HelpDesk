// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the Global type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web
{
    using System;
    using System.Globalization;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Security;

    using HelpDesk.ViewModels;

    using Newtonsoft.Json;

    /// <summary>
    /// The global.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        void Application_Start(object sender, EventArgs e)
        {
            // 應用程式啟動時執行的程式碼
            // RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// The application_ authenticate request.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (this.Request.IsAuthenticated)
            {
                //// this.ConvertToCustomUserOld();

                // 先取得該使用者的 FormsIdentity
                FormsIdentity id = (FormsIdentity)User.Identity;

                // 再取出使用者的 FormsAuthenticationTicket
                FormsAuthenticationTicket ticket = id.Ticket;

                // 將儲存在 FormsAuthenticationTicket 中的角色定義取出，並轉成字串陣列

                // string[] roles = ticket.UserData.Split(new char[] { ',' });
                var user = JsonConvert.DeserializeObject<UserViewModel>(ticket.UserData);

                // 指派角色到目前這個 HttpContext 的 User 物件去
                Context.User = new GenericPrincipal(Context.User.Identity, user.Roles);
            }
        }

        /// <summary>
        /// The application_ acquire request state.
        /// 語系切換時的判斷
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;

            if (context.Session != null)
            {
                foreach (string sessionKey in context.Session.Keys)
                {
                    if ("language".Equals(sessionKey))
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(context.Session["language"].ToString());
                        break;
                    }

                    context.Session.Add("language", "zh-tw");
                }
            }
        }
    }
}