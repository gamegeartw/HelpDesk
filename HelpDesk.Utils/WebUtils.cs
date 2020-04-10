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
    using System.Web.Configuration;
    using System.Web.UI;
    using HelpDesk.Models;

    using Landpy.ActiveDirectory.Core;

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

        /// <summary>
        /// The show ajax message.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        public static void ShowAjaxMessage(Page page,string message)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "Message", $"alert('{message}')", true);
        }

        /// <summary>
        /// The get ad operator.
        /// </summary>
        /// <returns>
        /// The <see cref="ADOperator"/>.
        /// </returns>
        public static IADOperator GetAdOperator()
        {
            var dc = WebConfigurationManager.AppSettings["DCName"];
            var user = WebConfigurationManager.AppSettings["ADUser"];
            var password = WebConfigurationManager.AppSettings["password"];
            return new ADOperator($"{dc}\\{user}", password, dc);
        }
    }
}
