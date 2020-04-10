using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk.Web
{
    using System.Web.Security;

    public partial class Signout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            this.Page.Response.Redirect(this.Page.ResolveClientUrl("~/"), true);
        }
    }
}