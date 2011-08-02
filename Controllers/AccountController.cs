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
        PolitiqEntities db = new PolitiqEntities();

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

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(PasswordResetView forgetfulmember)
        {
            try
            {
                Member currentMember = db.Members.First(member => member.LoginID == forgetfulmember.LoginID);

                PasswordResetManager passwordReset = new PasswordResetManager();
                passwordReset.ResetPassword(currentMember);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Username does not exist.");
            }
            return View();
           
        }

        public ActionResult Profile(int id)
        {
            return View(db.Members.First(member => member.MemberID == id));
        }

        // TODO: Include methods for edit profile & delete account.

    }
}
