using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk.Web.UserPages
{
    using HelpDesk.Models;

    public partial class OnCallList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<OnCallModel> SelectValue()
        {
            throw new NotImplementedException();
        }
    }
}