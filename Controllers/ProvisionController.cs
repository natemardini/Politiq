using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politiq.Models.ObjectModel;
using Politiq.Models;
using Politiq.Models.ObjectManager;

namespace Politiq.Controllers
{ 
    public class ProvisionController : Controller
    {
        private DAL db = new DAL();
        Legislation legislation; 

        //
        // GET: /Provision/

        public ViewResult Index()
        {
            return View(db.Provisions.ToList());
        }

        //
        // GET: /Provision/Details/5

        public ViewResult Details(int id)
        {
            Provision provision = db.Provisions.Find(id);
            return View(provision);
        }

        //
        // GET: /Provision/Create

        public ActionResult Create(int bill)
        {
            this.legislation = db.Legislations.Find(bill);
            ViewBag.BillName = this.legislation.LongTitle;
            ViewBag.BillStyle = LegislationManager.GenerateStyle(this.legislation);
            ViewBag.ArticleNumber = (this.legislation.Provisions.Count + 1).ToString();
            TempData["Bill"] = this.legislation.LegislationID;
            return View();
        } 

        //
        // POST: /Provision/Create

        [HttpPost]
        public ActionResult Create(NewProvisionView provision)
        {
            if (ModelState.IsValid)
            {
                int bill = int.Parse(TempData["Bill"].ToString());
                LegislationManager billManager = new LegislationManager();
                billManager.Include(provision, bill);
                return RedirectToAction("Index", "Home");  
            }

            return View(provision);
        }
        
        //
        // GET: /Provision/Edit/5
 
        public ActionResult Edit(int id)
        {
            Provision provision = db.Provisions.Find(id);
            return View(provision);
        }

        //
        // POST: /Provision/Edit/5

        [HttpPost]
        public ActionResult Edit(Provision provision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provision);
        }

        //
        // GET: /Provision/Delete/5
 
        public ActionResult Delete(int id)
        {
            Provision provision = db.Provisions.Find(id);
            return View(provision);
        }

        //
        // POST: /Provision/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Provision provision = db.Provisions.Find(id);
            db.Provisions.Remove(provision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}