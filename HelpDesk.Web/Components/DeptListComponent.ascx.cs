// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeptListComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   The dept list component.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HelpDesk.Models;
    using HelpDesk.Utils;

    using NLog;

    /// <summary>
    /// The dept list component.
    /// </summary>
    public partial class DeptListComponent : UserControl
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
                return string.Join(
                    ",",
                    this.ListBoxMain.Items.OfType<ListItem>().Where(m => m.Selected).Select(m => m.Value).ToList());
            }

            set
            {
                this.ViewState[nameof(this.DefaultValues)] = value;
            }
        }

        /// <summary>
        /// Gets or sets the selection mode.
        /// </summary>
        public ListSelectionMode SelectionMode
        {
            get
            {
                return this.ListBoxMain.SelectionMode;
            }

            set
            {
                this.ListBoxMain.SelectionMode = value;
            }
        }

        /// <summary>
        /// The select depts.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Dept}"/>.
        /// </returns>
        public IEnumerable<Dept> SelectDepts()
        {
            try
            {
                var results = new List<Dept>();
                foreach (var url in ServiceUtils.GetWebAPIUrl())
                {
                    results.AddRange(ServiceUtils.GetWebAPI<IEnumerable<Dept>>(url, "Depts", "GET", null));
                }

                return results;
            }
            catch (Exception e)
            {
                Logger.Error(e);
                this.Page.ModelState.AddModelError("Dept", e.Message);
            }

            return null;
        }

        /// <summary>
        /// The list box main_ on data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void ListBoxMain_OnDataBound(object sender, EventArgs e)
        {
            if (this.SelectValueList() != null)
            {
                foreach (ListItem item in this.ListBoxMain.Items)
                {
                    item.Selected = this.SelectValueList().Any(m => m.Equals(item.Value));
                }
            }
        }

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

        /// <summary>
        /// The select values.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string[] SelectValueList()
        {
            if (this.ViewState[nameof(this.DefaultValues)] != null)
            {
                var values = (string)this.ViewState[nameof(this.DefaultValues)];
                return values.Split(',');
            }

            return null;
        }
    }
}