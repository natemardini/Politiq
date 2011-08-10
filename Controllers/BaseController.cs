using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Politiq.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        //[HttpPost]
        //public ActionResult Maintenance(string auth)
        //{
        //    if (auth == "578F6GTEFH4SGS4J6RR120X36")
        //    {
        //        var maintain = new Helpers.Maintainance();
        //        try
        //        {
        //            maintain.MoveBills();
        //            maintain.Report();

        //            string tomorrow = DateTime.Now.AddHours(24).ToString();
        //            string uri = @"https://momentapp.com/jobs/5ECnr6Ed.json?job[at]=" + tomorrow + @"&job[method]=POST&job[uri]=http://polsim.appharbor.net/Maintenance/Base/auth=578F6GTEFH4SGS4J6RR120X36&apikey=ycYtLJNMEMP6ii_qdNT2";
        //            return Redirect(uri); 
        //        }
        //        catch (Exception)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
