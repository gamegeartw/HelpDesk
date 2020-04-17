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

    using HelpDesk.Enums;

    /// <summary>
    /// The process detail model.
    /// </summary>
    public class ProcessDetailModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the doc no.
        /// </summary>
        public string DocNo { get; set; }

        /// <summary>
        /// Gets or sets the process desc.
        /// </summary>
        public string ProcessDesc { get; set; }

        /// <summary>
        /// Gets or sets the emp name.
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 附加檔案
        /// </summary>
        public string AdditionalFile { get; set; }

        /// <summary>
        /// Gets or sets the mail list.
        /// </summary>
        public string MailList { get; set; }

        /// <summary>
        /// Gets or sets the process status.
        /// </summary>
        public ProcessStatus ProcessStatus { get; set; } = ProcessStatus.Process;
    }
}
