// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebUtils.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the WebUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;

    using Landpy.ActiveDirectory.Core;

    using RestSharp;
    using RestSharp.Serialization.Json;

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
        public static UserData GetUser(HttpContext ctx)
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
            var dc = ConfigurationManager.AppSettings["DCName"];
            var user = ConfigurationManager.AppSettings["ADUser"];
            var password = ConfigurationManager.AppSettings["password"];
            return new ADOperator($"{dc}\\{user}", password, dc);
        }

        public static string GetConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// The show page message.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="message">
        /// The s.
        /// </param>
        public static void ShowPageMessage(Page page, string message)
        {
            var master = page.Master;
            if (master == null)
            {
                throw new ArgumentNullException(nameof(page.Master), "找不到控制項");
            }
            var literal = (Literal)master.FindControl("LiteralMsg");
            literal.Text = $@"
                <div class='alert alert-success alert-dismissible'>
                    <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>
                    <h4><i class='icon fa fa-check'></i> Success!</h4>
                    {message}
                </div>";
            literal.Visible = true;
        }
    }
}
