// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessDetailModel.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   Defines the ProcessDetailModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HelpDesk.Enums;

    /// <summary>
    /// The process detail model.
    /// </summary>
    public class ProcessDetailModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 單據編號
        /// </summary>
        [Required]
        public string DocNo { get; set; }

        /// <summary>
        /// 案件流水號
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// 處理經過
        /// </summary>
        [Required]
        public string ProcessDesc { get; set; }

        /// <summary>
        /// 處理人員
        /// </summary>
        [Required]
        public string EmpName { get; set; }

        /// <summary>
        /// 送修廠商處理
        /// </summary>
        public bool OnService { get; set; }

        /// <summary>
        /// 送修時間
        /// </summary>
        public DateTime? OnServiceTime { get; set; }

        /// <summary>
        /// 返修時間
        /// </summary>
        public DateTime? OnServiceFinishTime { get; set; }

        /// <summary>
        /// 建檔時間
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 附加檔案
        /// </summary>
        public string AdditionalFile { get; set; }

        /// <summary>
        /// 寄信地址
        /// </summary>
        public string MailList { get; set; }

        /// <summary>
        /// 處理進度
        /// </summary>
        public ProcessStatus ProcessStatus { get; set; } = ProcessStatus.Process;

        /// <summary>
        /// 使用工時
        /// </summary>
        public decimal ProcessTime { get; set; }
    }
}
