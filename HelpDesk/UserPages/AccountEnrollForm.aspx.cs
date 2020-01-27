// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountEnrollForm.aspx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   帳號申請頁面
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.UserPages
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 帳號申請頁面
    /// </summary>
    public partial class AccountEnrollForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
        }

        protected void CheckBox_OnCheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            if (chk == null)
            {
                return;
            }

            var panel = this.FormViewMain.FindControl(chk.ID.Replace("CheckBox", "Panel"));

            foreach (var ctl in panel.Controls.OfType<WebControl>())
            {
                ctl.Enabled = chk.Checked;
            }
        }
    }
}