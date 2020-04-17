// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountEnrollViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   帳號申請
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;

    using HelpDesk.Enums;

    /// <summary>
    /// 帳號申請
    /// </summary>
    public class AccountEnrollViewModel
    {
        /// <summary>
        /// 單號
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// 員工
        /// </summary>
        public string Employee => $"{this.EmpNo}-{this.EmpName}";

        /// <summary>
        /// 工號
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 部門代號
        /// </summary>
        public string DeptNo { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime EnrollDate { get; set; }

        /// <summary>
        /// 需求日期
        /// </summary>
        public DateTime? RequireDate { get; set; }

        /// <summary>
        /// 需求類別
        /// </summary>
        public int RequiredMode { get; set; }

        /// <summary>
        /// 驗收模式
        /// </summary>
        public int FinishMode { get; set; }

        /// <summary>
        /// 申請AD帳號
        /// </summary>
        public bool AllowADAccount { get; set; } = false;

        /// <summary>
        /// AD Account
        /// </summary>
        public string ADAccount { get; set; }

        /// <summary>
        /// Gets or sets the ad password.
        /// </summary>
        public string ADPassword { get; set; }

        /// <summary>
        /// Email空間,預設100M
        /// </summary>
        public int EmailQuota { get; set; } = 100;

        /// <summary>
        /// 是否需要主管覆核
        /// </summary>
        public bool RequireBossEnroll => this.EmailQuota > 100;

        /// <summary>
        /// 申請【資料夾】使用權限
        /// </summary>
        public bool AllowPublicFolder { get; set; } = false;

        /// <summary>
        /// 專案資料夾位置
        /// </summary>
        public string PublicFolderPath { get; set; }

        /// <summary>
        /// 專案資料夾會辦人員
        /// </summary>
        public string RSVPPublicFolderEmpNo { get; set; }

        /// <summary>
        /// 申請Internet權限
        /// </summary>
        public bool AllowInternet { get; set; } = false;

        /// <summary>
        /// Gets or sets the require internet reason.
        /// </summary>
        public string RequireInternetReason { get; set; }

        /// <summary>
        /// 是否需要理級主管覆核
        /// </summary>
        public bool RequiredCenterBoss => this.AllowInternet;

        /// <summary>
        /// Gets or sets a value indicating whether allow tms account.
        /// </summary>
        public bool AllowTMSAccount { get; set; } = false;

        /// <summary>
        /// 申請其他帳號
        /// </summary>
        public bool IsExtraEnroll { get; set; } = false;

        /// <summary>
        /// 申請其他帳號的需求
        /// </summary>
        public string ExtraEnroll { get; set; }

        /// <summary>
        /// 申請其他帳號的原因
        /// </summary>
        public string ExtraEnrollReason { get; set; }

        /// <summary>
        /// 目前進度
        /// </summary>
        public ProcessStatus Status { get; set; }
    }
}
