// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ADUserViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   The ad user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.AccessControl;

    using HelpDesk.Enums;

    /// <summary>
    /// The ad user view model.
    /// </summary>
    public class ADUserViewModel
    {
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        [Required(ErrorMessage = "帳號不得為空")]
        //[RegularExpression("^[a-zA-Z0-9]+[.]{1}[a-zA-Z0-9]+", ErrorMessage = "帳號格式錯誤(format error)")]
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the ext number.
        /// </summary>
        public string ExtNumber { get; set; }

        /// <summary>
        /// Gets or sets the emp no.
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// Gets or sets the ad type.
        /// </summary>
        public ADType ADType { get; set; }

        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        public string CompanyCode { get; set; }

        public string DisplayName { get; set; }
    }
}