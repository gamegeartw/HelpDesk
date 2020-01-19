using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Services
{
    /// <summary>
    /// The base service.
    /// </summary>
    /// <typeparam name="T">
    /// T is Repo
    /// </typeparam>
    public class BaseService<T> 
        where T : class, IDisposable
    {


        public BaseService()
        {

        }

    }
}
