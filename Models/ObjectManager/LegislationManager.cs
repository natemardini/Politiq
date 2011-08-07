using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models.ObjectModel;
using Politiq.Models;

namespace Politiq.Models.ObjectManager
{
    public class LegislationManager
    {
        DAL db = new DAL();

        public string GenerateStyle(Legislation legislation)
        {
            string style_letter;
            if (legislation.OriginatingChamber == 2)
            {
                style_letter = "S";
            }
            else
            {
                style_letter = "C";
            }

            if (legislation.BillType == 1)
            {
                var currentPublicBills = db.Legislations.Where(l => l.BillType == 1 & l.Parliament.LegislativeSessionID == legislation.Parliament.LegislativeSessionID);

                legislation.BillNumber = currentPublicBills.Count() + 1;
            }
            else
            {
                var currentPrivateBills = db.Legislations.Where(l => l.BillType == 2 & l.Parliament.LegislativeSessionID == legislation.Parliament.LegislativeSessionID);

                legislation.BillNumber = currentPrivateBills.Count() + 201;
            }

            return style_letter + "-" + legislation.BillNumber.ToString();
        }
    }
}