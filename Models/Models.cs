using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Politiq.Models.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Politiq.Helpers;

namespace Politiq.Models
{
    public class Member
    {
        public int MemberID { get; private set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

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

        [Required]
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

        public virtual OiC EnactingOrder { get; set; }

        [Required]
        public virtual Member Proponent { get; set; }

        public virtual Legislation InBill { get; set; }

        public DateTime Enactment { get; set; }

        public EnactmentType EnactmentType { get; set; }
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

        public bool Dissolved { get; set; }

        public ICollection<Legislation> Bills { get; set; }
    }

    public class EnactmentType
    {
        public int EnactmentTypeNumber { get;  set; }
        public string EnactmentTypeText
        {
            get
            {
                switch (this.EnactmentTypeNumber)
                {
                    case 1:
                        return "Enacted upon Royal Assent";
                    case 2:
                        return "Set specific date";
                    case 3:
                        return "Enacted by Order in Council";
                    default:
                        return "Enacted upon Royal Assent";
                }
            }
        }
    }
    
    // DBContext class

    public class DAL : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Legislation> Legislations { get; set; }
        public DbSet<Provision> Provisions { get; set; }
        public DbSet<OiC> OiCs { get; set; }
        public DbSet<LegislativeSession> LegislativeSessions { get; set; }
    }
}