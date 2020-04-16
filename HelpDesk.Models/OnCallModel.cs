// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallModel.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   Defines the OnCallModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The on call model.
    /// </summary>
    public class OnCallModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the doc no.
        /// </summary>
        [Display(Name = "單據編號")]
        public string DocNo { get; set; }

        /// <summary>
        /// 部門編號
        /// </summary>
        [Display(Name = "部門編號")]
        [Required]
        public string DeptNo { get; set; }

        /// <summary>
        /// 部門名稱
        /// </summary>
        [Display(Name = "部門名稱")]
        public string DeptName { get; set; }

        /// <summary>
        /// 叫修人員工號
        /// </summary>
        [Display(Name = "叫修人員工號")]
        [Required]
        public string EmpNo { get; set; }

        /// <summary>
        /// 叫修人員姓名
        /// </summary>
        [Display(Name = "叫修人員姓名")]
        public string EmpName { get; set; }

        /// <summary>
        /// 報修項目
        /// </summary>
        [Display(Name = "報修項目")]
        [Required]
        public string OnCallType { get; set; }

        /// <summary>
        /// 連絡電話
        /// </summary>
        [Display(Name = "連絡電話")]
        public string ExtNumber { get; set; }

        /// <summary>
        /// 報修原因
        /// </summary>
        [Display(Name = "報修原因")]
        public string OnCallReason { get; set; }

        /// <summary>
        /// 建檔時間
        /// </summary>
        [Display(Name = "建檔時間")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 結案時間
        /// </summary>
        [Display(Name = "結案時間")]
        public DateTime? CloseTime { get; set; }

        /// <summary>
        /// 處理人員
        /// </summary>
        [Display(Name = "處理人員")]
        public string ProcessUser { get; set; }

        /// <summary>
        /// 處理時間(分鐘)
        /// </summary>
        [Display(Name = "處理時間(分鐘)")]
        public double ProcessTime { get; set; }

        /// <summary>
        /// 驗收簽名
        /// </summary>
        [Display(Name = "驗收簽名")]
        public string SignPath { get; set; }

        /// <summary>
        /// 負責人確認
        /// </summary>
        [Display(Name = "負責人確認")]
        public string CommitUser { get; set; }

        /// <summary>
        /// 處理經過
        /// </summary>
        [Display(Name = "處理經過")]
        public ProcessDetailModel[] ProcessDetails { get; set; }
    }
}
