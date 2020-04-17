// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessStatus.cs" company="NAFCO">
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
    public enum ProcessStatus
    {
        /// <summary>
        /// The none.
        /// </summary>
        [EnumDisplay("未設定")]
        None = 0,

        /// <summary>
        /// 已申請
        /// </summary>
        [EnumDisplay("已申請")]
        Enroll,

        /// <summary>
        /// 處理中
        /// </summary>
        [EnumDisplay("處理中")]
        Process,

        /// <summary>
        /// 送修中
        /// </summary>
        [EnumDisplay("送修中")]
        OnService,

        /// <summary>
        /// 送修結束
        /// </summary>
        [EnumDisplay("送修結束")]
        OnServiceFinish,

        /// <summary>
        /// The finish.
        /// </summary>
        [EnumDisplay("已完成")]
        Finish,

        /// <summary>
        /// The rollback.
        /// </summary>
        [EnumDisplay("退件")]
        Rollback,
    }
}
