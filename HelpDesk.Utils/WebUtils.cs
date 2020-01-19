// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebUtils.cs" company="NAFCO">
//   NAFCO.Utils
// </copyright>
// <summary>
//   Defines the WebUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Utils
{
    using System.Security.Principal;

    using HelpDesk.Models;

    /// <summary>
    /// The web utils.
    /// </summary>
    public static class WebUtils
    {
        /// <summary>
        /// The get user.
        /// </summary>
        /// <param name="ctx">
        /// The ctx.
        /// </param>
        /// <returns>
        /// The <see cref="UserData"/>.
        /// </returns>
        public static UserData GetUser(System.Web.HttpContext ctx)
        {
            if (ctx.User.Identity.IsAuthenticated)
            {
                var empNo = ctx.User.Identity.Name;
            }

            return null;
        }
    }
}
