using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Politiq.Models.DB;
using System.Web.Helpers;

namespace Politiq.Models.ObjectManager
{
    public class PasswordResetManager
    {
        PolitiqEntities politiq = new PolitiqEntities();

        public void ResetPassword(Member _member)
        {
            Member currentMember = politiq.Members.First(member => member.LoginID == _member.LoginID);
            string newPassword = GeneratePassword(8);
            currentMember.Password = Crypto.HashPassword(newPassword);
            currentMember.LastName = newPassword; // Remove this line, used only for testing. 
            politiq.SaveChanges();

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