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
        public virtual int LegislationID { get; private set; }

       
        public virtual int BillNumber { get; set; }

        [Required]
        public virtual int OriginatingChamber { get; set; }

        
        public virtual int BillType { get; set; }

        [Required]
        public virtual string LongTitle { get; set; }

        public virtual string ShortTile { get; set; }

        public virtual string Preamble { get; set; }

        
        public virtual ICollection<Provision> Provisions { get; set; }

        public virtual int Stage { get; set; }

        [Required]
        public virtual Member Sponsor { get; set; }

        public virtual LegislativeSession Parliament { get; set; }
    }

    public class Provision
    {
        public virtual int ProvisionID { get; private set; }

        [Required]
        public virtual decimal Article { get; set; }

        [Required]
        public virtual string Text { get; set; }

        public virtual OiC EnactingOrder { get; set; }

        [Required]
        public virtual Member Proponent { get; set; }

        public virtual Legislation InBill { get; set; }

        public virtual DateTime Enactment { get; set; }
    }

    public class OiC
    {
        public int OicID { get; private set; }

        public string Style { get; set; }

        [Required]
        public string Text { get; set; }

        public ICollection<Provision> EnactedProvisions { get; set; }

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

        public DateTime EnactingDate { get; set; }

    }
}