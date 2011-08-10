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

        public int OriginatingChamber { get; set; }
 
        public int BillType { get; set; }

        public string LongTitle { get; set; }

        public string ShortTile { get; set; }

        public string Preamble { get; set; }

        public bool Confidence { get; set; }

        public virtual ICollection<Provision> Provisions { get; set; }

        public virtual Stage Stage { get; set; }

        public virtual Member Sponsor { get; set; }

        public virtual CommonsSession Parliament { get; set; }

        public virtual ICollection<VoteHistory> Hansard { get; set; }

    }

    public class Provision
    {
        public int ProvisionID { get; set; }

        public int Article { get; set; }

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

        public string Text { get; set; }

        public virtual ICollection<Enactment> ArticleEnactments { get; set; }

        public virtual Member Enactor { get; set; }

        public DateTime EnactingDate { get; set; }

        public DateTime OiCDate { get; set; }

    }

    public class Stage
    {
        public int StageID { get; set; }

        public int Reading { get; set; }

        public virtual ICollection<Ballot> BallotsCast { get; set; }

        public DateTime LastMovement { get; set; }
    }

    public class VoteHistory
    {
        public int VoteHistoryID { get; set; }

        public virtual Legislation ForBill { get; set; }

        public virtual Stage AtStage { get; set; }

        public virtual ICollection<Ballot> BallotsCasted { get; set; }

        public int Yeas { get; set; }

        public int Nays { get; set; }

        public int Abstains { get; set; }
    }

    public class Ballot
    {
        public int BallotID { get; set; }

        public int Vote { get; set; }                      // 1: Yea, 2: Nay, 3: Abstain

        public virtual Member Voter { get; set; }
    }
}