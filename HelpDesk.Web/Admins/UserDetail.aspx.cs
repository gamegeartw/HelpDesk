// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDetail.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The user detail.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Admins
{
    using System;
    using System.Web.ModelBinding;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.Services;
    using HelpDesk.Utils;

    using Landpy.ActiveDirectory.Entity.Object;

    using NLog;

    /// <summary>
    /// The user detail.
    /// </summary>
    public partial class UserDetail : Page
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
        /// The select db user.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="UserData"/>.
        /// </returns>
        public UserData SelectDBUser([QueryString("account")] string account)
        {
            return null;
        }

        /// <summary>
        /// The select user.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="UserObject"/>.
        /// </returns>
        public UserObject SelectUser([QueryString("account")] string account)
        {
            try
            {
                return this.Service.Get(account);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                this.ModelState.AddModelError("AD", ex.Message);
            }

            return null;
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
                this.MetaDescription = "使用者明細";
                this.FormViewAD.Visible = this.Request.QueryString["type"] == "AD";
            }
        }

        protected void FormViewAD_OnItemCommand(object sender, FormViewCommandEventArgs e)
        {
            // throw new NotImplementedException();
            try
            {
                var inputValue = string.Empty;
                if (e.CommandName == "ResetPassword")
                {
                    var txt = this.FormViewAD.FindControl("TextBoxResetPassword") as TextBox;
                    if (txt == null)
                    {
                        throw new ArgumentNullException(e.CommandName, "無此欄位");
                    }

                    inputValue = txt.Text.Trim();
                }
                else if (e.CommandName == "UpdateTelePhone")
                {
                    var txt = this.FormViewAD.FindControl("TextBoxTelephone") as TextBox;
                    if (txt == null)
                    {
                        throw new ArgumentNullException(e.CommandName, "無此欄位");
                    }

                    inputValue = txt.Text.Trim();
                }

                if (string.IsNullOrWhiteSpace(inputValue))
                {
                    throw new ArgumentNullException(e.CommandName, "輸入的值不得為空");
                }

                var @type = this.Service.GetType();
                var method = @type.GetMethod(e.CommandName);
                if (method != null)
                {
                    var ex = (Exception)method.Invoke(
                        this.Service,
                        new object[] { e.CommandArgument, inputValue });
                    if (ex != null)
                    {
                      throw ex;
                    }

                    WebUtils.ShowAjaxMessage(this.Page, "作業成功");
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                this.ModelState.AddModelError("ResetPassword", exception.Message);
            }
        }
    }
}