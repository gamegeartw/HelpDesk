// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The users component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using HelpDesk.Utils;

    using NLog;

    /// <summary>
    /// The users component.
    /// </summary>
    public partial class UsersComponent : UserControl
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<KeyValuePair<string,string>> SelectValue()
        {
            try
            {
                var list = WebUtils.GetWebAPI<IEnumerable<ViewModels.EmployeeViewModel>>(
                    WebUtils.GetWebAPIUrl(),
                    "Users",
                    "GET",
                    null);
                var result = new List<KeyValuePair<string, string>>();
                foreach (var model in list.OrderBy(m => m.EMPNO))
                {
                    result.Add(new KeyValuePair<string, string>($"{model.EMPNO}-{model.NAME}", model.EMPNO));
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("Employee", e.Message);
            }

            return null;
        }
    }
}