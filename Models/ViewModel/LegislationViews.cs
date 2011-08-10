using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Politiq.Models.ObjectModel
{
    public class NewLegislationView
    {
        [Required]
        public int OriginatingChamber { get; set; }


        public int BillType { get; set; }

        [Required]
        public string LongTitle { get; set; }

        public string ShortTile { get; set; }

        public string Preamble { get; set; }
    }

    public class NewProvisionView
    {
        [Required]
        public string Text { get; set; }

        public string EnactingDate { get; set; }
    }
}