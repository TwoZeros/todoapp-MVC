﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace todoapp.services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.mail.ru");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("todoapp@bk.ru", "1(rPaitaRII1");
            smtpClient.EnableSsl = true;
            var mail = new MailMessage();
            mail.From = new MailAddress("todoapp@bk.ru");
            mail.To.Add(email);
            mail.Subject = subject;

            mail.Body = message.Replace("&amp;", "&");
            smtpClient.Send(mail);
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
