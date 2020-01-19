// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeptNoDropDownListComponent.ascx.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   Defines the DeptNoDropDownListComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI.WebControls;

    /// <summary>
    /// The dept no drop down list component.
    /// </summary>
    public partial class DeptNoDropDownListComponent : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the dept no.
        /// </summary>
        public string DeptNo
        {
            get
            {
                return (string)this.ViewState[nameof(this.DeptNo)];
            }

            set
            {
                this.ViewState[nameof(this.DeptNo)] = value;
            }
        }

        /// <summary>
        /// The select depts.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> SelectDepts()
        {
            return null;
        }

        /// <summary>
        /// The drop down list main_ on data bound.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DropDownListMain_OnDataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            if (ddl != null)
            {
                foreach (var item in ddl.Items.OfType<ListItem>())
                {
                    if (item.Value == this.DeptNo)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }
    }
}