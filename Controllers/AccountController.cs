using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politiq.Models.ViewModels;
using Politiq.Models.ObjectManager;
using System.Web.Security;

namespace Politiq.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(MemberView member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MemberManager memberManager = new MemberManager();
                    if (!memberManager.IsMemberLoginIDExist(member.LoginID))
                    {
                        memberManager.Add(member);
                        FormsAuthentication.SetAuthCookie(member.FirstName, false);
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login ID already taken");
                    }
                }
            }
            catch
            {
                return View(member);
            }

            return View(member);
        }

        // TODO: Include methods for Login, edit profile and delete account.

    }
}
