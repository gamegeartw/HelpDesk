// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormSearchViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   The form search view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The form search view model.
    /// </summary>
    [Serializable]
    public class FormSearchViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        [Display(Name = "關鍵字查詢")]
        public string SearchText { get; set; }

        /// <summary>
        /// Gets or sets the doc no.
        /// </summary>
        [Display(Name = "單據號碼")]
        public string DocNo { get; set; }

        /// <summary>
        /// Gets or sets the dept no.
        /// </summary>
        [Display(Name = "部門")]
        public string DeptNo { get; set; }

        /// <summary>
        /// Gets or sets the emp no.
        /// </summary>
        [Display(Name = "員工工號")]
        public string EmpNo { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [Display(Name = "開始日期")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        [Display(Name = "結束日期")]
        public DateTime? CloseDate { get; set; }
    }
}
