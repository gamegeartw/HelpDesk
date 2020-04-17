// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dept.cs" company="NAFCO">
//   HelpDesk.Models
// </copyright>
// <summary>
//   The dept.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The dept.
    /// </summary>
    public class Dept
    {
        /// <summary>
        /// Gets or sets the dept no.
        /// </summary>
        [Display(Name = "單位編號")]
        public string DeptNo { get; set; }

        /// <summary>
        /// Gets or sets the dept name.
        /// </summary>
        [Display(Name = "單位名稱")]
        public string DeptName_C { get; set; }

        /// <summary>
        /// Gets or sets the dept name_ e.
        /// </summary>
        public string DeptName_E { get; set; }

        /// <summary>
        /// The display name.
        /// </summary>
        [Display(Name = "顯示名稱")]
        public string DisplayName => $"{DeptNo}-{DeptName_C}({DeptName_E})";
    }
}
