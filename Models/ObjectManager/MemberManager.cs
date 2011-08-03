using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models.DB;
using Politiq.Models.ViewModels;
using System.Web.Helpers;
using System.Data.Objects;

namespace Politiq.Models.ObjectManager
{
    public class MemberManager
    {
        private PolitiqEntities politiq = new PolitiqEntities();

        public void Add(NewMemberView member)
        {
            DB.Member Member = new DB.Member();
            Member.LoginID = member.LoginID;
            Member.Password = Crypto.HashPassword(member.Password);
            Member.FirstName = member.FirstName;
            Member.LastName = member.LastName;
            Member.Email = member.Email;

            politiq.Members.AddObject(Member);
            politiq.SaveChanges();
        }

        public void Change(ChangeMemberView member)
        {
            Member Member = politiq.Members.First(m => m.MemberID == member.MemberID);

            Member.FirstName = member.FirstName.TrimEnd();
            Member.LastName = member.LastName.TrimEnd();
            Member.Email = member.Email.TrimEnd();
            if (member.Password != null && member.Password.StartsWith(" ") == false)
            {
                Member.Password = Crypto.HashPassword(member.Password);
            }

            politiq.SaveChanges();
        }

        public bool IsMemberLoginIDExist(string memberLogIn)
        {
            return (from o in politiq.Members
                    where o.LoginID == memberLogIn
                    select o).Any();
        }
    }
}