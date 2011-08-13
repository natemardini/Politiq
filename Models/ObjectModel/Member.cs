using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace Politiq.Models.ObjectModel
{
    public class Member
    {
        public int MemberID { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [StringLength(300)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public virtual ICollection<Legislation> DraftedBills { get; set; }

        public virtual Party Party { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public DateTime LastActivity { get; set; }

        public virtual ICollection<Ballot> VoteRecord { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }

        public int RoleLevel { get; set; }        // 1: MP, 2: Critic, 3: Whip, 4: House Leader, 5: Leader, 6: Minister, 7: PM, 8: Editor, 9 Speaker, 10: GG. 

        public string ShortTitle { get; set; }

        public string LongName { get; set; }

        public int AccessClearance { get; set; }

        public virtual ICollection<Member> WithMembers { get; set; }

    }

    public class Party
    {
        public int PartyID { get; set; }

        public string ShortName { get; set; }

        public string Abbrev { get; set; }

        public string Name { get; set; }

        public int Seats { get; set; }

        public virtual CommonsGroup House_Side { get; set; }

        public virtual ICollection<Member> Members { get; set; }

        public virtual ICollection<Message> Thread { get; set; }
    }     
}