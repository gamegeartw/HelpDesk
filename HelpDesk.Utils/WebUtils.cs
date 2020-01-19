using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Utils
{
    using System.Net.Http;

    public static class WebUtils
    {
        /// <summary>
        /// The data page desc.
        /// </summary>
        /// <param name="templateString">
        /// The template string.
        /// </param>
        /// <param name="startRowIndex">
        /// The start row index.
        /// </param>
        /// <param name="maxCount">
        /// The max count.
        /// </param>
        /// <param name="totalRowCount">
        /// The total row count.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string DataPageDesc(
            string templateString,
            int startRowIndex,
            int maxCount,
            int totalRowCount)
        {
            return string.Format(templateString, startRowIndex, maxCount, totalRowCount);
        }
    }
}
