using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politiq.Models.ViewModels;
using Politiq.Models.ObjectManager;
using System.Web.Security;
using Politiq.Models.DB;
using System.Web.Helpers;

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
            if (member.Password == member.ConfirmPassword)
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
            }
            else
            {
                ModelState.AddModelError("", "Your password and confirmation do not match.");
            }

            return View(member);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView returningMember)
        {
            PolitiqEntities db = new PolitiqEntities();

            var dbMember = from o in db.Members
                           where o.LoginID == returningMember.LoginID
                           select o;

            if (dbMember.Any())
            {
                var currentMember = dbMember.Single();
                if (Crypto.VerifyHashedPassword(currentMember.Password, returningMember.Password))
                {
                    FormsAuthentication.SetAuthCookie(currentMember.FirstName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username not recognized.");
            }
            return View();
        }

        // TODO: Include methods for edit profile, delete account and resetting password.

    }
}
