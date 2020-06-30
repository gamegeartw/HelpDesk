// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceUtils.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the ServiceUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Web;

    using HelpDesk.ViewModels;

    using RestSharp;
    using RestSharp.Serialization.Json;

    /// <summary>
    /// The service utils.
    /// </summary>
    public static class ServiceUtils
    {
        /// <summary>
        /// The get safe string.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSafeString(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }

            return o.ToString();
        }

        /// <summary>
        /// The get connection.
        /// </summary>
        /// <param name="connName">
        /// The conn name.
        /// </param>
        /// <returns>
        /// The <see cref="IDbConnection"/>.
        /// </returns>
        public static IDbConnection GetConnection(string connName)
        {
            var connCollSettings = ConfigurationManager.ConnectionStrings[connName];
            var factory = System.Data.Common.DbProviderFactories.GetFactory(connCollSettings.ProviderName);
            
            var conn = factory.CreateConnection();
            if (conn != null)
            {
                conn.ConnectionString = connCollSettings.ConnectionString;
                conn.Open();
                return conn;
            }

            return null;
        }

        /// <summary>
        /// The get web api url.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string[] GetWebAPIUrl()
        {
            return ConfigurationManager.AppSettings["WEBAPI"].Split(',');
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
        /// T is List or Object
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
                    request.AddQueryParameter(pair.Key, (string)pair.Value);
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

        /// <summary>
        /// The get employees from erp.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{EmployeeViewModel}"/>.
        /// </returns>
        public static IEnumerable<EmployeeViewModel> GetEmployeesFromERP()
        {
            var results = new List<EmployeeViewModel>();

            foreach (var url in GetWebAPIUrl())
            {
                results.AddRange(GetWebAPI<IEnumerable<EmployeeViewModel>>(url, "Users", "GET", null));
            }

            return results.Distinct(new EmployeeCompare());
        }

        /// <summary>
        /// The get employee.
        /// </summary>
        /// <param name="empNo">
        /// The emp no.
        /// </param>
        /// <returns>
        /// The <see cref="EmployeeViewModel"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static EmployeeViewModel GetEmployee(string empNo)
        {
            var param = new KeyValuePair<string, object>("id", empNo);
            var @params = new List<KeyValuePair<string, object>> { param };

            var results = new List<EmployeeViewModel>();
            try
            {
                foreach (var url in GetWebAPIUrl())
                {
                    results.AddRange(ServiceUtils.GetWebAPI<IEnumerable<EmployeeViewModel>>(
                        url,
                        "Users",
                        "GET",
                        @params));
                }
            }
            catch
            {
                // Ignore
            }



            if (!results.Any())
            {
                throw new ArgumentNullException("user", "人員未註冊在ERP內");
            }

            return results.First();
        }
    }
}
