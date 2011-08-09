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

        public Stage Stage { get; set; }

        public virtual Member Sponsor { get; set; }

        public virtual LegislativeSession Parliament { get; set; }

        public virtual ICollection<VoteHistory> Hansard { get; set; }

    }

    public class Provision
    {
        public int ProvisionID { get; set; }

        [Required]
        public int Article { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Enactment Enactment { get; set; }

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

    public class Stage
    {
        public int StageID { get; set; }
        public int Reading { get; set; }
        public virtual ICollection<Member> VotesFor { get; set; }
        public virtual ICollection<Member> VotesAgainst { get; set; }
        public virtual ICollection<Member> Abstentions { get; set; }
        public DateTime LastMovement { get; set; }
    }

    public class VoteHistory
    {
        public int VoteHistoryID { get; set; }
        public virtual Legislation ForBill { get; set; }
        public virtual Stage AtStage { get; set; }
        public virtual ICollection<Member> MPs_For { get; set; }
        public virtual ICollection<Member> MPs_Against { get; set; }
        public virtual ICollection<Member> MPs_Abstained { get; set; }
        public int Yeas { get; set; }
        public int Nays { get; set; }
        public int Abstains { get; set; }
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