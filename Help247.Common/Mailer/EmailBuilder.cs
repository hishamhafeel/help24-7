using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using MailKit.Security;

namespace Help247.Common.Mailer
{
    public class EmailBuilder
    {
       
        private static string From;

        private static string DisplayName => "Help 24/7";

        private static string Pwd;

        public EmailBuilder(IConfiguration configuration)
        {

            From = configuration["Email:credentials:username"];
            Pwd = configuration["Email:credentials:password"];
        }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsBodyHtml { get; set; }

        public string[] To { get; set; }

        public static void SendEmail(EmailBuilder messageBuilder)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(DisplayName, From));
                foreach (var emailAddress in messageBuilder.To)
                {
                    message.To.Add(new MailboxAddress(DisplayName, emailAddress));
                }
                message.Subject = messageBuilder.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = messageBuilder.Body
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.Auto);

                    //SMTP server authentication if needed
                    client.Authenticate(From, Pwd);

                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }

       
    }
}
