using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politiq.Models.ObjectModel;
using Politiq.Models.ObjectManager;
using System.Web.Security;
using Politiq.Models;
using System.Web.Helpers;

namespace Politiq.Controllers
{
    public class AccountController : Controller
    {
        DAL db = new DAL();

        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(NewMemberModel newMember)
        {
                try
                {
                    if (ModelState.IsValid)
                    {
                        MemberManager memberManager = new MemberManager();
                        if (!memberManager.UsernameExist(newMember.Username))
                        {
                            memberManager.Add(newMember);
                            FormsAuthentication.SetAuthCookie(newMember.FirstName, false);
                            return RedirectToAction("Welcome", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Username already taken.");
                            
                        }
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.ToString());
                    
                }

                return View(newMember);
        }

        // GET: /Account/Login

        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(LoginMemberModel returningMember)
        {
            try
            {
                Member currentMember = db.Members.First(member => member.Username == returningMember.Username);

                if (Crypto.VerifyHashedPassword(currentMember.Password, returningMember.Password))
                {
                    FormsAuthentication.SetAuthCookie(returningMember.Username.ToLower(), returningMember.RememberMe);
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
        public ActionResult ForgotPassword(ResetMemberPasswordModel member)
        {
            try
            {
                Member currentMember = db.Members.Single(m => m.Username == member.Username);

                MemberManager memberManager = new MemberManager();
                memberManager.ResetPassword(currentMember);
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
            return View(db.Members.Find(id));  
        }

        // GET: /Account/Edit?id=#

        public ActionResult Edit(int id)
        {
            Member currentMember = db.Members.Find(id);
            ChangeMemberModel editMember = new ChangeMemberModel
            {
                MemberID = currentMember.MemberID,
                FirstName = currentMember.FirstName,
                LastName = currentMember.LastName,
                Email = currentMember.Email,
                Password = ""
            };
            return View(editMember);
        }

        // POST: /Account/Edit?id=#
        [HttpPost]
        public ActionResult Edit(ChangeMemberModel edittedMember)
        {
            try
            {
                MemberManager memberManager = new MemberManager();
                memberManager.Change(edittedMember);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ModelState.AddModelError("", "Could not save changes.");
                return View();
            }
        }

        // GET: /Account/Delete?id=#
        [HttpDelete]
        public EmptyResult DeleteConfirm(int id)
        {

                db.Members.Remove(db.Members.Find(id));
                db.SaveChanges();
                FormsAuthentication.SignOut();

                return null;
        }
    }
}
