using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Politiq.Models.ObjectModel
{
    // Model Entities

    public class Legislation
    {
        public int LegislationID { get; set; }

       
        public int BillNumber { get; set; }

        [Required]
        public int OriginatingChamber { get; set; }

        
        public int BillType { get; set; }

        [Required]
        public string LongTitle { get; set; }

        public string ShortTile { get; set; }

        public string Preamble { get; set; }

        
        public virtual ICollection<Provision> Provisions { get; set; }

        public int Stage { get; set; }

        public virtual Member Sponsor { get; set; }

        public virtual LegislativeSession Parliament { get; set; }
    }

    public class Provision
    {
        public int ProvisionID { get; set; }

        [Required]
        public int Article { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Enactment Enactment { get; set; }

        [Required]
        public virtual Member Proponent { get; set; }

        public virtual Legislation InBill { get; set; }
    }

    public class Enactment
    {
        public int EnactmentID { get; set; }

        public int EnactmentType { get; set; }

        public virtual OiC EnactingOrder { get; set; }

        public DateTime EnactingDate { get; set; }
    }

    public class OiC
    {
        public int OicID { get; private set; }

        public string Style { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<Enactment> ArticleEnactments { get; set; }

        [Required]
        public Member Enactor { get; set; }

        public DateTime EnactingDate { get; set; }

        [Required]
        public DateTime OiCDate { get; set; }

    }

    public class LegislativeSession
    {
        public int LegislativeSessionID { get; private set; }

        [Required]
        public int Legislature { get; set; }

        [Required]
        public int Session { get; set; }

        [Required]
        public DateTime Opening { get; set; }

        public DateTime Ending { get; set; }

        public bool Dissolved { get; set; }

        public ICollection<Legislation> Bills { get; set; }
    }

    // Model Views

    public class NewLegislationView
    {
        [Required]
        public int OriginatingChamber { get; set; }


        public int BillType { get; set; }

        [Required]
        public string LongTitle { get; set; }

        public string ShortTile { get; set; }

        public string Preamble { get; set; }


    //    public ICollection<Provision> Provisions { get; set; }

    }

    public class NewProvisionView
    {
        [Required]
        public string Text { get; set; }

        public string EnactingDate { get; set; }

    }


}