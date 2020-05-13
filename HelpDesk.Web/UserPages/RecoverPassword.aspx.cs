// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecoverPassword.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The recover password.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Reflection;
    using System.Web.UI.WebControls;

    using HelpDesk.Services;
    using HelpDesk.Utils;
    using HelpDesk.ViewModels;

    using NLog;

    /// <summary>
    /// The recover password.
    /// </summary>
    public partial class RecoverPassword : System.Web.UI.Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The service.
        /// </summary>
        private ADService Service => new ADService(WebUtils.GetAdOperator());

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.Service?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The insert value and reset password.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void InsertValueAndResetPassword(EmployeeViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    Logger.Info($"ERP EmpNo={model.EMPNO}");
                    Logger.Info($"Windows Account={model.CC_MAIL_NAME}");
                    var user = ServiceUtils.GetEmployee(model.EMPNO);
                    if (!user.CC_MAIL_NAME.StartsWith(model.CC_MAIL_NAME, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ArgumentNullException(MethodBase.GetCurrentMethod().Name, "Windows 帳號不符合");
                    }

                    var seed = new Random();
                    var randomPassword = $"Nafco@{seed.Next(9999):0000}";
                    this.Service.ResetPassword($"{model.CC_MAIL_NAME}", randomPassword);
                    WebUtils.ShowAjaxMessage(this.Page, "帳號已解鎖並重置密碼(Account has reset)");
                    WebUtils.ShowPageMessage(
                        this.Page,
                        $"帳號已解鎖並重置密碼,帳號:{model.CC_MAIL_NAME},新的密碼:<span style='background-color:yellow'><font color='red'>{randomPassword}</font></span> (Account has reset(Account:{model.CC_MAIL_NAME}),new password:<span style='background-color:yellow'><font color='red'>{randomPassword}</font></span>)");
                    Logger.Info($"帳號已解鎖並重置密碼,帳號:{model.CC_MAIL_NAME},新的密碼:{randomPassword}");
                }

                this.ModelState.Clear();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                Logger.Error(e);
                this.ModelState.AddModelError("passwordReset", e.Message);
            }
        }

        /// <summary>
        /// The form view main_ on item inserted.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void FormViewMain_OnItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            // Ignore
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
                this.MetaDescription = "Windows 密碼恢復";
            }
        }
    }
}