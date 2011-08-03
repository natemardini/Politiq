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

        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(NewMemberView member)
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

        // GET: /Account/Login

        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(LoginView returningMember)
        {
            try
            {
                Member currentMember = db.Members.First(member => member.LoginID == returningMember.LoginID);

                if (Crypto.VerifyHashedPassword(currentMember.Password, returningMember.Password))
                {
                    FormsAuthentication.SetAuthCookie(currentMember.LoginID, returningMember.RememberMe);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect password.");
                }

            }
            catch
            {
                ModelState.AddModelError("", "Username not reccognized.");
            }
            return View();
        }

        // GET: /Account/Logout

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/ForgotPassword

        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword

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

        // GET: /Account/Profile?id=#

        public ActionResult Profile(int id)
        {
            return View(db.Members.First(member => member.MemberID == id));  
        }

        // GET: /Account/Edit?id=#

        public ActionResult Edit(int id)
        {
            Member currentMember = db.Members.First(member => member.MemberID == id);
            ChangeMemberView edittingMember = new ChangeMemberView();
            edittingMember.MemberID = currentMember.MemberID;
            edittingMember.FirstName = currentMember.FirstName;
            edittingMember.LastName = currentMember.LastName;
            edittingMember.Email = currentMember.Email;
            currentMember.Password = "";
            return View(edittingMember);
        }

        // POST: /Account/Edit?id=#
        [HttpPost]
        public ActionResult Edit(ChangeMemberView edittedmember)
        {
            try
            {
                MemberManager memberManager = new MemberManager();
                memberManager.Change(edittedmember);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ModelState.AddModelError("", "Could not save changes.");
                return View();
            }
        }

        // GET: /Account/Delete?id=#

        public ActionResult Delete(int id)
        {
            try
            {
                db.DeleteObject(db.Members.First(member => member.MemberID == id));
                db.SaveChanges();

                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception)
            {   
            }
            return RedirectToAction("Profile");
        }

        // TODO: Include methods for edit profile.

    }
}
