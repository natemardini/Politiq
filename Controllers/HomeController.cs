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
            string test = "[Howdy #how# are you?] [I'm good thank you]";
            return Politiq.Helpers.Formatting.ConvertScribToHtml(test);
        }
    }
}
