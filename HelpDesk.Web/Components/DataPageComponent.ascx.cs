using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelpDesk.Web.Components
{
    public partial class DataPageComponent : System.Web.UI.UserControl
    {
        /// <summary>
        /// Gets or sets the paged control id.
        /// </summary>
        public string PagedControlID
        {
            get
            {
                return this.DataPager1.PagedControlID;
            }

            set
            {
                this.DataPager1.PagedControlID = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ignore
        }
    }
}