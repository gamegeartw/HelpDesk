// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceUtils.cs" company="NAFCO">
//   HelpDesk 
// </copyright>
// <summary>
//   Defines the ServiceUtils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Utils
{
    using System.Configuration;
    using System.Data;

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
    }
}
