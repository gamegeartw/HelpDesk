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
    using System.Web.UI.WebControls;

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
        /// Gets or sets the default values.
        /// </summary>
        public string DefaultValues
        {
            get
            {
                var items = this.ListBoxMain.Items.OfType<ListItem>().Where(m => m.Selected).ToList();
                if (items.Any())
                {
                    return string.Join(",", items.Select(m => m.Value));
                }

                return string.Empty;
            }

            set
            {
                this.ViewState[nameof(this.DefaultValues)] = value;
            }
        }

        /// <summary>
        /// Gets the list items.
        /// </summary>
        public IEnumerable<ListItem> ListItems => this.ListBoxMain.Items.OfType<ListItem>();

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
                var list = ServiceUtils.GetEmployeesFromERP();
                var result = new List<KeyValuePair<string, string>>();
                foreach (var model in list.OrderBy(m => m.EMPNO))
                {
                    var mail = model.CC_MAIL_NAME;
                    var engName = string.Empty;
                    if (!string.IsNullOrWhiteSpace(mail))
                    {
                        engName = mail.Split('@')[0];
                    }

                    result.Add(new KeyValuePair<string, string>($"{model.EMPNO}-{model.NAME}({engName})", model.EMPNO));
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

        protected void ListBoxMain_OnDataBound(object sender, EventArgs e)
        {
            var values = (string)this.ViewState[nameof(this.DefaultValues)];
            List<string> selectedItems = new List<string>();

            if (!string.IsNullOrWhiteSpace(values))
            {
                selectedItems = values.Split(',').ToList();
            }

            foreach (var li in this.ListBoxMain.Items.OfType<ListItem>())
            {
                li.Selected = selectedItems.Any(m => m.Equals(li.Value) || li.Text.ToLower().Contains(m.ToLower()));
            }
        }
    }
}