// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Status.cs" company="NAFCO">
//   HelpDesk.Enums
// </copyright>
// <summary>
//   處理進度
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Enums
{
    /// <summary>
    /// 處理進度
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// The none.
        /// </summary>
        [Display("未設定")]
        None = 0,

        /// <summary>
        /// The enroll.
        /// </summary>
        [Display("已申請")]
        Enroll = 1,

        /// <summary>
        /// The process.
        /// </summary>
        [Display("處理中")]
        Process = 2,

        /// <summary>
        /// The finish.
        /// </summary>
        [Display("已完成")]
        Finish = 3,

        /// <summary>
        /// The rollback.
        /// </summary>
        [Display("退件")]
        Rollback = 4,
    }
}
