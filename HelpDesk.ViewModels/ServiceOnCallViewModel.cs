// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceOnCallViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   The service on call view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;

    /// <summary>
    /// The service on call view model.
    /// </summary>
    public class ServiceOnCallViewModel
    {
        /// <summary>
        /// 叫修單位
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 建檔時間
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 叫修人員工號
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 叫修人員姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 處理人員
        /// </summary>
        public string ServiceUser { get; set; }

        /// <summary>
        /// 完成時間
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        /// 花費工時
        /// </summary>
        public double ProcessTime { get; set; }

        /// <summary>
        /// 叫修狀況
        /// </summary>
        public string UserReport { get; set; }

        /// <summary>
        /// 叫修原因
        /// </summary>
        public string OnCallReason { get; set; }

        /// <summary>
        /// 處理結果
        /// </summary>
        public string ServiceDesc { get; set; }

        /// <summary>
        /// 驗收人員
        /// </summary>
        public string CommitUser { get; set; }

        /// <summary>
        /// 驗收人員簽名
        /// </summary>
        public byte[] CommitSign { get; set; }

        /// <summary>
        /// 資訊部門主管
        /// </summary>
        public string Manager { get; set; }
    }
}
