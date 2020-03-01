// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the RouteConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk
{
    using System.Web.Routing;

    /// <summary>
    /// The route config.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// The register routes.
        /// </summary>
        /// <param name="routes">
        /// The routes.
        /// </param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            // var settings = new FriendlyUrlSettings();
            // settings.AutoRedirectMode = RedirectMode.Permanent;
            // routes.EnableFriendlyUrls(settings);
        }
    }
}
