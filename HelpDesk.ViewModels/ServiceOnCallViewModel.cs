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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using HelpDesk.Enums;

    /// <summary>
    /// The service on call view model.
    /// </summary>
    public class ServiceOnCallViewModel
    {
        public string DocNo { get; set; }

        /// <summary>
        /// 送修單位
        /// </summary>
        [Required]
        [Display(Name = "送修單位")]
        public string DeptNo { get; set; }

        /// <summary>
        /// 送修單位名稱
        /// </summary>
        [Display(Name = "送修單位名稱")]
        public string DeptName { get; set; }
        
        /// <summary>
        /// 送修人員姓名
        /// </summary>
        [Display(Name = "送修人員姓名")]
        public string EmpName { get; set; }

        /// <summary>
        /// 送修人員工號
        /// </summary>
        [Required]
        [Display(Name = "送修人員工號")]
        public string EmpNo { get; set; }

        /// <summary>
        /// 處理人員
        /// </summary>
        [Display(Name = "處理人員")]
        public string ProcessUser { get; set; }

        /// <summary>
        /// 建檔時間
        /// </summary>
        [Display(Name = "建檔時間")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 連絡電話
        /// </summary>
        [Required]
        [Display(Name = "連絡電話")]
        public string ExtNumber { get; set; }

        /// <summary>
        /// 發信清單
        /// </summary>
        [Display(Name = "發信清單")]
        public string MailList { get; set; }

        /// <summary>
        /// 送修廠商時間
        /// </summary>
        [Display(Name = "送修廠商時間")]
        public DateTime? OnServiceTime { get; set; }

        /// <summary>
        /// 返修時間
        /// </summary>
        [Display(Name = "返修時間")]
        public DateTime? OnServiceFinishTime { get; set; }

        /// <summary>
        /// 送修廠商人員
        /// </summary>
        [Display(Name = "送修廠商人員")]
        public string OnServiceUser { get; set; }

        /// <summary>
        /// 結案時間
        /// </summary>
        [Display(Name = "結案時間")]
        public DateTime? CloseTime { get; set; }

        /// <summary>
        /// 花費工時(分鐘)
        /// </summary>
        [Display(Name = "花費工時(分鐘)")]
        public double ProcessTime { get; set; }

        /// <summary>
        /// 送修類別
        /// </summary>
        [Required]
        [Display(Name = "送修類別")]
        public string OnCallType { get; set; }

        /// <summary>
        /// 送修原因
        /// </summary>
        [Display(Name = "送修原因")]
        public string OnCallReason { get; set; }

        /// <summary>
        /// 處理結果
        /// </summary>
        [Display(Name = "處理結果")]
        public string ServiceDesc { get; set; }

        /// <summary>
        /// 驗收人員
        /// </summary>
        [Display(Name = "驗收人員")]
        public string CommitUser { get; set; }

        /// <summary>
        /// 驗收人員簽名
        /// </summary>
        [Display(Name = "驗收人員簽名")]
        public string SignPath { get; set; }

        /// <summary>
        /// 資訊部門主管
        /// </summary>
        [Display(Name = "資訊部門主管")]
        public string Manager { get; set; }

        /// <summary>
        /// 案件處理進度
        /// </summary>
        [DefaultValue(ProcessStatus.None)]
        [Display(Name = "案件處理進度")]
        public ProcessStatus ProcessStatus { get; set; }
    }
}
