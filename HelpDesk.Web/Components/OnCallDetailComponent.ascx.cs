// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnCallDetailComponent.ascx.cs" company="NAFCO">
//   HelpDesk.Web
// </copyright>
// <summary>
//   Defines the OnCallDetailComponent type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk.Web.Components
{
    using System;

    using HelpDesk.Models;

    public partial class OnCallDetailComponent : System.Web.UI.UserControl
    {
        public string DocNo
        {
            get
            {
                return (string)this.ViewState[nameof(this.DocNo)];
            }

            set
            {
                this.ViewState[nameof(this.DocNo)] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public OnCallModel Select()
        {
            throw new NotImplementedException();
        }
    }
}