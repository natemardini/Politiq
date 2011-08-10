using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Data.Objects;
using Politiq.Models.ObjectModel;


namespace Politiq.Models.ObjectManager
{
    public class MemberManager
    {
        private DAL db = new DAL();

        public Member Add(NewMemberModel newMember)
        {
            Member member = new Member
            {
                Username = newMember.Username,
                FirstName = newMember.FirstName,
                LastName = newMember.LastName,
                Email = newMember.Email,
                LastActivity = DateTime.Now,
                Password = Crypto.HashPassword(newMember.Password)
            };

            db.Members.Add(member);
            db.SaveChanges();

            return member;
        }

        public void Change(ChangeMemberModel member)
        {
            Member currentMember = db.Members.Find(member.MemberID);

            currentMember.FirstName = member.FirstName.TrimEnd();
            currentMember.LastName = member.LastName.TrimEnd();
            currentMember.Email = member.Email.TrimEnd();
            if (member.Password != null && member.Password.StartsWith(" ") == false)
            {
                currentMember.Password = Crypto.HashPassword(member.Password);
            }

            db.SaveChanges();
        }

        public bool UsernameExist(string memberLogIn)
        {
            return (from o in db.Members
                    where o.Username == memberLogIn
                    select o).Any();
        }

        public void ResetPassword(Member member)
        {
            string newPassword = GeneratePassword(8);
            member.Password = Crypto.HashPassword(newPassword);
            db.SaveChanges();

            //try
            //{
            //    string emailbody = "Your password has been reset per your request. Your new password is: " + currentMember.Password + ". Please log in and change it as soon as you can.";

            //    WebMail.SmtpServer = "my.smtp.server";
            //    WebMail.Send(currentMember.Email.ToString(),
            //                 "Politiq - Password Reset",
            //                 emailbody,
            //                 "polcan@polcan.net"
            //                );
            //}
            //catch (Exception)
            //{
            //    // Exception
            //}
        }

        private string GeneratePassword(int charNumber)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < charNumber; i++)
            {
                int x = random.Next(1, chars.Length);
                password += chars.GetValue(x).ToString();
            }

            return password;
        }
    }
}