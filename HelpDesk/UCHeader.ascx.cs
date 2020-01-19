using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownListLng_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // this.Session["Language"] = this.DropDownListLng.SelectedValue;
            // this.Page.DataBind();
        }
    }
}