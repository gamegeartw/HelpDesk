// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BtnList.cs" company="NAFCO">
//   HelpDesk.Enums
// </copyright>
// <summary>
//   The btn list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Enums
{
    /// <summary>
    /// The btn list.
    /// </summary>
    public enum BtnList
    {
        /// <summary>
        /// 未指定
        /// </summary>
        None   = 0b0000_0000_0000_0000,

        /// <summary>
        /// 建立
        /// </summary>
        Create = 0b0000_0000_0000_0001,

        /// <summary>
        /// 新增資料
        /// </summary>
        Insert = 0b0000_0000_0000_0010,

        /// <summary>
        /// 編輯
        /// </summary>
        Edit   = 0b0000_0000_0000_0100,

        /// <summary>
        /// 更新資料
        /// </summary>
        Update = 0b0000_0000_0000_1000,

        /// <summary>
        /// 刪除
        /// </summary>
        Delete = 0b0000_0000_0001_0000,

        /// <summary>
        /// 明細
        /// </summary>
        Detail = 0b0000_0000_0010_0000,

        /// <summary>
        /// The cancel.
        /// </summary>
        Cancel = 0b0000_0000_0100_0000,
    }
}
