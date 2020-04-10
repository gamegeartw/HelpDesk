// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Login.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the Login type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web
{
    using System;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Security;
    using System.Web.UI;

    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;

    using Newtonsoft.Json;

    using NLog;

    /// <summary>
    /// The login.
    /// </summary>
    public partial class Login : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The user.
        /// </summary>
        private UserViewModel user;

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
                this.Page.MetaDescription = "Login page";
            }
        }

        /// <summary>
        /// The unnamed 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            this.Session.RemoveAll();
            try
            {
                if (this.ValidateLogin(this.account.Value, this.password.Value))
                {
                    // 將管理者登入的 Cookie 設定成 Session Cookie
                    bool isPersistent = false;

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,
                        this.account.Value,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(30),
                        isPersistent,
                        JsonConvert.SerializeObject(this.user),
                        FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    // Create the cookie.
                    this.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    this.Response.Redirect(this.ResolveClientUrl("~/"), true);
                }

                this.ModelState.AddModelError("error", "帳號密碼錯誤");
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                this.ModelState.AddModelError("login", exception.Message);
            }
        }

        /// <summary>
        /// 驗證使用者是否登入成功(By AD)
        /// </summary>
        /// <param name="strUsername">登入帳號</param>
        /// <param name="strPassword">登入密碼</param>
        /// <returns>return boolean</returns>
        private bool ValidateLogin(string strUsername, string strPassword)
        {
            var result = false;

            var dc = WebConfigurationManager.AppSettings["DCName"];
            this.user = new UserViewModel
                            {
                                Roles = new[] { "user" }, 
                                Name = strUsername
                            };
            var util = new Landpy.ActiveDirectory.Password.PasswordUnity();
            result = util.IsPasswordValid($"{dc}\\{strUsername}", strPassword);
            if (result)
            {
                using (var service = new ADService(WebUtils.GetAdOperator()))
                {
                    var userObject = service.Get(strUsername);
                    if (userObject.IsAccountOperator || userObject.IsDomainAdmin)
                    {
                        this.user.Roles = new[] { "user", "admin" };
                    }
                }
            }

            return result;
        }
    }
}