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
        [Key]
        public int MemberID { get; set; }
        
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

        public virtual ICollection<Legislation> DraftedBills { get; set; }

        public virtual Party Party { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public DateTime LastLogin { get; set; }
    }

    public class Role
    {
        public int RoleID { get; set; }

        public int RoleLevel { get; set; }        // 1: MP, 2: Critic, 3: Whip, 4: House Leader, 5: Leader, 6: Minister, 7: PM, 8: Editor, 9 Speaker, 10: GG. 

        public string ShortTitle { get; set; }

        public string LongName { get; set; }

        public IList<int> AccessClearance { get; set; }

        public virtual ICollection<Member> WithMembers { get; set; }

    }

    public class NewMemberModel
    {
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
        [Display(Name = "Password")]
        public string Password { get; set; }

        [EqualTo("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginMemberModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }

    public class ChangeMemberModel
    {
        [Required]
        public int MemberID { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    public class ResetMemberPasswordModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}