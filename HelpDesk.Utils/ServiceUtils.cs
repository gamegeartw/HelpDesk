using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Utils
{
    public static class ServiceUtils
    {
        /// <summary>
        /// The get safe string.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetSafeString(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }

            return o.ToString();
        }
    }
}
