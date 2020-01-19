// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePage.cs" company="NAFCO">
//   HelpDesk.ASP.NET
// </copyright>
// <summary>
//   The base page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HelpDesk
{
    using System.Web.UI;

    /// <summary>
    /// The base page.
    /// </summary>
    public class BasePage : Page
    {
        /// <summary>
        /// The initialize culture.
        /// </summary>
        protected override void InitializeCulture()
        {
            if (Request.Form["ctl00$UCHeader$DropDownListLng"] != null)
            {
                Page.UICulture = Request.Form["ctl00$UCHeader$DropDownListLng"];
            }

            // base.InitializeCulture();
        }
    }
}