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
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.Services;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="OnCall"/> class.
        /// </summary>
        public OnCall()
        {
            this.Service = new OnCallService(new SqlConnection(WebUtils.GetConnString("Intranet_DB_Write")));
        }

        /// <summary>
        /// The service.
        /// </summary>
        private OnCallService Service { get; }

        /// <summary>
        /// The dispose.
        /// </summary>
        public override void Dispose()
        {
            this.Service?.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// The insert value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void InsertValue(ServiceOnCallViewModel value)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    value.CreateTime = DateTime.Now;
                    this.Service.Insert(value);
                    WebUtils.ShowAjaxMessage(this.Page, "作業成功");
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.ModelState.AddModelError("error", e.Message);
            }
        }

        /// <summary>
        /// The form view main_ on item created.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void FormViewMain_OnItemCreated(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var uc = (UsersComponent)this.FormViewMain.FindControl("UsersComponent");
                uc.DefaultValues = this.User.Identity.Name;
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
            if (!this.IsPostBack)
            {
                this.MetaDescription = "叫修作業";
            }
        }

        protected void FormViewMain_OnItemInserting(object sender, FormViewInsertEventArgs e)
        {
            // var deptNo = e.Values["DeptNo"];
            // if (deptNo == null)
            // {
            //     return;
            // }
            //
            // var dept = WebUtils.GetWebAPI<Dept>(
            //     WebUtils.GetWebAPIUrl(),
            //     "Depts",
            //     "GET",
            //     new List<KeyValuePair<string, object>>
            //         {
            //             new KeyValuePair<string, object>("id", deptNo)
            //         });
            // e.Values["DeptName"] = dept.DisplayName;

            var empNo = e.Values["EmpNo"];
            if (empNo == null)
            {
                return;
            }

            var employee = WebUtils.GetWebAPI<EmployeeViewModel>(
                WebUtils.GetWebAPIUrl(),
                "Users",
                "GET",
                new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("id", empNo)
                    });
            e.Values["EmpName"] = employee.NAME;
            e.Values["DeptNo"] = employee.DEPTNO;
            e.Values["DeptName"] = $"{employee.DEPTNO}-{employee.DeptName_C}";
        }
    }
}