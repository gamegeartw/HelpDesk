// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomPrincipal.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Custom Principal
//   To custom your user data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web
{
    using System.Security.Principal;

    using HelpDesk.ViewModels;

    /// <summary>
    /// Custom Principal
    /// To custom your user data
    /// </summary>
    public class CustomPrincipal : GenericPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomPrincipal"/> class.
        /// </summary>
        /// <param name="identity">
        /// The identity.
        /// </param>
        /// <param name="roles">
        /// The roles.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public CustomPrincipal(IIdentity identity, string[] roles, UserViewModel user)
            : base(identity, roles)
        {
            this.UserData = user;

            // TODO: Do something...
        }

        /// <summary>
        /// Gets or sets the user data.
        /// </summary>
        public UserViewModel UserData { get; set; }
    }
}