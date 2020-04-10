// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserViewModel.cs" company="NAFCO">
//   HelpDesk.ViewModels
// </copyright>
// <summary>
//   The user view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The user view model.
    /// </summary>
    [Serializable]
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [Display(Name = "工號")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        [Display(Name = "角色")]
        public string[] Roles { get; set; }
    }
}
