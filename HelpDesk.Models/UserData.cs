// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserData.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   The user data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;

    using HelpDesk.Enums;

    /// <summary>
    /// The user data.
    /// </summary>
    [Serializable]
    public class UserData : BaseClass
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 員工資料
        /// </summary>
        public string Empolyee => $"{this.EmpNo}-{this.EmpName}";

        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime EnrollDate { get; set; }

        /// <summary>
        /// 最後變更日期
        /// </summary>
        public DateTime? ModifyDate { get; set; }

        /// <summary>
        /// 變更人員
        /// </summary>
        public string ModifyUser { get; set; }

        /// <summary>
        /// 目前進度
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Gets or sets the dept.
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// Gets or sets the boss.
        /// </summary>
        public string Boss { get; set; }

        /// <summary>
        /// Gets or sets the boss data.
        /// </summary>
        public UserData BossData { get; set; }
    }
}
