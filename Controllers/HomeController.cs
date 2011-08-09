using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Politiq.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Welcome
        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        public string Regex()
        {
            int yeas = (int)decimal.Truncate(((10 / 13) * 58));
            return yeas.ToString();
        }
    }
}
