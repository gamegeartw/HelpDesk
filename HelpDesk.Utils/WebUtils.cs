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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.UI;
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

        public static string GetConnString(string name)
        {
            return WebConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// The get web api url.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetWebAPIUrl()
        {
            return WebConfigurationManager.AppSettings["WEBAPI"];
        }

        /// <summary>
        /// The get web api.
        /// </summary>
        /// <param name="baseUrl">
        /// The base url.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="paramList">
        /// The param list.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="HttpException">
        /// </exception>
        public static T GetWebAPI<T>(string baseUrl, string path,string method, IList<KeyValuePair<string, object>> paramList)
        {
            var client = new RestClient(baseUrl);
            client.Encoding = Encoding.UTF8;
            var request = new RestRequest(path, (Method)Enum.Parse(typeof(Method), method));
            if (paramList != null)
            {
                foreach (var pair in paramList)
                {
                    request.AddUrlSegment(pair.Key, pair.Value);
                }
            }

            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                throw new HttpException((int)response.StatusCode, response.ErrorMessage);
            }

            var serializer = new JsonDeserializer();

            return serializer.Deserialize<T>(response);
        }
    }
}
