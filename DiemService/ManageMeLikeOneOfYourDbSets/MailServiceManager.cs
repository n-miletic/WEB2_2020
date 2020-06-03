using DiemService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DiemService.ManageMeLikeOneOfYourDbSets
{
    public static  class MailServiceManager
    {
        public static void RegisterSendEmail(TempUser user)
        {
            if (user == null)
                return;
            using (var _context = new DiemServiceDB())
            {
                _context.TempUserDbSet.Add(user);
                _context.SaveChanges();
            }

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("diem.service.api@gmail.com");
            mail.To.Add(user.Email);
            mail.Subject = "User activation email";
            mail.Body = "Click this link to activate email: " + "localhost:4200/ActivateUser/" + user.ActivationLink;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("diem.service.api@gmail.com", "web2projekat2020");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public static void ActivateUser(string actId)
        {
            using (var _context = new DiemServiceDB())
            {
                TempUser toAdd = _context.TempUserDbSet.Where(s => s.ActivationLink == actId).FirstOrDefault();
                if (toAdd == null)
                {
                    throw new Exception("Activation link expired or wrong");
                }
                    
                _context.UserDbSet.Add(new User(toAdd));
                _context.TempUserDbSet.Remove(toAdd);
                _context.SaveChanges();
            }

        }

        public static void RemoveExpiredLinks()
        {
            using (var _context = new DiemServiceDB())
            {
                if (_context.TempUserDbSet.Any())
                    _context.TempUserDbSet.RemoveRange(_context.TempUserDbSet.Where(s => s.ExpiryDate < DateTime.Now));
                _context.SaveChanges();
            }
        }
    }
}