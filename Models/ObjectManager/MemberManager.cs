using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models.DB;
using Politiq.Models.ViewModels;

namespace Politiq.Models.ObjectManager
{
    public class MemberManager
    {
        private PolitiqEntities politiq = new PolitiqEntities();

        public void Add(MemberView member)
        {
            DB.Member Member = new DB.Member();
            Member.LoginID = member.LoginID;
            Member.Password = member.Password;
            Member.FirstName = member.FirstName;
            Member.LastName = member.LastName;

            politiq.AddToMembers(Member);
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