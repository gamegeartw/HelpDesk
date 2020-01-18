using System.Web.Mvc;

namespace HelpDesk.Web.MVC.Helpers
{
    public static class FormSerachHelper
    {
        public static string SearchLabel(this HtmlHelper helper,string controlColumn, string title)
        {
            var builder = new TagBuilder("Label");
            builder.MergeAttribute("for",controlColumn);
            builder.AddCssClass("control-label");
            builder.SetInnerText(title);
            return builder.ToString(TagRenderMode.Normal);
        }
    }
}