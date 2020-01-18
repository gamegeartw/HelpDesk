using System;
using System.Web.Mvc;

namespace HelpDesk.Web.MVC.Controllers
{
    public class FormsAccountController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                
                }

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}