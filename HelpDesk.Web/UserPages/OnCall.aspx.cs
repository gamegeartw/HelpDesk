// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCall.aspx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   叫修頁面
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.UserPages
{
    using System;
    using System.Web.UI;

    using NLog;

    /// <summary>
    /// 叫修頁面
    /// </summary>
    public partial class OnCall : Page
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void InsertValue()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}