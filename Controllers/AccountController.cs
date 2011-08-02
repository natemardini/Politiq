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

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Account/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
