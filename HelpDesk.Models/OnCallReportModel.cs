// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallReportModel.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   報修進度
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System;

    /// <summary>
    /// 報修進度
    /// </summary>
    public class OnCallReportModel
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 單據編號
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// 單據序號
        /// </summary>
        public int SeqNo { get; set; }

        /// <summary>
        /// 處理人員
        /// </summary>
        public string ProcessUser { get; set; }

        /// <summary>
        /// 處理過程
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 處理時間
        /// </summary>
        public DateTime ProcessTime { get; set; }

        /// <summary>
        /// 處理進度
        /// </summary>
        public Enums.ProcessStatus ProcessStatus { get; set; }
    }
}
