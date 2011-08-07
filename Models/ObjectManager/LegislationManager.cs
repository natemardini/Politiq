using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models.ObjectModel;
using Politiq.Models;
using System.Data.SqlTypes;

namespace Politiq.Models.ObjectManager
{
    public class LegislationManager
    {
        DAL db = new DAL();

        public void Add(NewLegislationView legislation)
        {
            Legislation newLegislation = new Legislation();
            // Simple transfers
            newLegislation.ShortTile = legislation.ShortTile;
            newLegislation.LongTitle = legislation.LongTitle;
            newLegislation.BillType = legislation.BillType;
            newLegislation.OriginatingChamber = legislation.OriginatingChamber;
            newLegislation.Preamble = legislation.Preamble;
            
            // More complicated properties
            newLegislation.Stage = 1;
            this.NumberBill(newLegislation); // Provides bill number
            newLegislation.Parliament = db.LegislativeSessions.First(p => p.Ending >= DateTime.Today);
            newLegislation.Sponsor = db.Members.Single(m => m.Username == HttpContext.Current.User.Identity.Name);

            // And save
            db.Legislations.Add(newLegislation);
            db.SaveChanges();
        }

        public Legislation Save(NewLegislationView legislation)
        {
            Legislation newLegislation = new Legislation();
            // Simple transfers
            newLegislation.ShortTile = legislation.ShortTile;
            newLegislation.LongTitle = legislation.LongTitle;
            newLegislation.BillType = legislation.BillType;
            newLegislation.OriginatingChamber = legislation.OriginatingChamber;
            newLegislation.Preamble = legislation.Preamble;

            // More complicated properties
            newLegislation.Stage = 1;
            this.NumberBill(newLegislation); // Provides bill number
            newLegislation.Parliament = db.LegislativeSessions.First(p => p.Ending >= DateTime.Today);
            newLegislation.Sponsor = db.Members.Single(m => m.Username == HttpContext.Current.User.Identity.Name);

            // And save
            db.Legislations.Add(newLegislation);
            db.SaveChanges();

            // return the saved legislation
            return newLegislation;
        }

        public void Include(NewProvisionView article, int bill)
        {
            var legislation = db.Legislations.Find(bill); 
            Provision provision = new Provision
            {
              Article = legislation.Provisions.Count + 1,
              Text = article.Text,
              Enactment = article.EnactingDate,
              Proponent = db.Members.Single(m => m.Username == HttpContext.Current.User.Identity.ToString())
            };

            legislation.Provisions.Add(provision);
            db.SaveChanges();
        }

        public void NumberBill(Legislation legislation)
        {
            switch (legislation.BillType)
            {
            case 1:
                    var currentPublicBills = db.Legislations.Where(l => l.BillType == 1 & l.Parliament.Ending >= DateTime.Today);

                    legislation.BillNumber = currentPublicBills.Count() + 1;
                    break;
            case 2:
                    var currentPrivateBills = db.Legislations.Where(l => l.BillType == 2 & l.Parliament.Ending >= DateTime.Today);

                    legislation.BillNumber = currentPrivateBills.Count() + 201;
                    break;
            }
        }

        public string GenerateStyle(Legislation legislation)
        {
            string style_letter = (legislation.OriginatingChamber == 2) ? "S" : "C";  
            return style_letter + "-" + legislation.BillNumber.ToString();
        }
    }
}