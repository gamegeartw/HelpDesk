// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   Defines the DeviceViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The device view model.
    /// </summary>
    public class DeviceViewModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Display(Name = "編號")]
        public string No { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [Display(Name = "品名")]
        public string Name { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        [Display(Name = "數量")]
        public decimal Count { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [Display(Name = "成本")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 保管人
        /// </summary>
        [Display(Name = "保管人")]
        public string User { get; set; }

        /// <summary>
        /// 地點
        /// </summary>
        [Display(Name = "地點")]
        public string Location { get; set; }

        /// <summary>
        /// 入帳時間
        /// </summary>
        [Display(Name = "入帳時間")]
        public DateTime? ImportTime { get; set; }

        /// <summary>
        /// 建檔時間
        /// </summary>
        [Display(Name = "建檔時間")]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
