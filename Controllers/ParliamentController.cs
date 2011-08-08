using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Politiq.Models.ObjectModel;
using Politiq.Models;

namespace Politiq.Controllers
{
    public class ParliamentController : Controller
    {
        private DAL db = new DAL();

        //
        // GET: /Parliament/

        [HttpPost]
        public int Open()
        {
            var lastSession = db.LegislativeSessions.OrderByDescending(p => p.Ending).FirstOrDefault();

            if (lastSession != null && lastSession.Ending > DateTime.Now)
            {
                return 1;
            }

            var newSession = new LegislativeSession
                {
                    Opening = DateTime.Now,
                    Ending = DateTime.Now.AddYears(5),
                    Dissolved = false
                };
            
            if(lastSession == null)
            {
                newSession.Legislature = 41;
                newSession.Session = 1; 
            }
            else
            {
                if (lastSession.Dissolved == true)
                {
                    newSession.Legislature = lastSession.Legislature + 1;
                    newSession.Session = 1;
                }
                else
                {
                    newSession.Legislature = lastSession.Legislature;
                    newSession.Session = lastSession.Session + 1;
                }
            }

            db.LegislativeSessions.Add(newSession);
            db.SaveChanges();

            return 0;
        }

        [HttpPost]
        public int Prorogue()
        {
            var lastSession = db.LegislativeSessions.OrderByDescending(p => p.Ending).FirstOrDefault();

            if (lastSession.Ending < DateTime.Now)
            {
                return 1;
            }
            else
            {
                lastSession.Ending = DateTime.Now;
                db.SaveChanges();
                return 0;
            }
        }

        [HttpPost]
        public int Dissolve()
        {
            var lastSession = db.LegislativeSessions.OrderByDescending(p => p.Ending).FirstOrDefault();

            if (lastSession.Ending < DateTime.Now)
            {
                return 0;
            }
            else
            {
                lastSession.Ending = DateTime.Now;
                lastSession.Dissolved = true;
                db.SaveChanges();
                return 1;
            }
        }
    }
}