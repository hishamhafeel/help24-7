using System;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Security;
using System.Net.Mail;
using System.Net;

namespace Help247.Common.Mailer
{
    public class EmailBuilder
    {
       
        private static string From;

        private static string DisplayName => "Help 24/7";

        private static string Pwd;
        private static string server = "mail.247helps.com";
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
                MailMessage m = new MailMessage();
                SmtpClient sc = new SmtpClient();
                m.From = new MailAddress(From);
                foreach (var emailAddress in messageBuilder.To)
                {
                    m.To.Add(emailAddress);
                }
                m.Subject = messageBuilder.Subject;
                m.Body = messageBuilder.Body;
                m.IsBodyHtml = true;
                sc.Host = server;
                sc.Port = 25;
                sc.Credentials = new System.Net.NetworkCredential(From, Pwd);
                sc.EnableSsl = false;
                sc.Send(m);
                //var message = new MimeMessage();
                //message.From.Add(new MailboxAddress(DisplayName, From));
                //foreach (var emailAddress in messageBuilder.To)
                //{
                //    message.To.Add(new MailboxAddress(DisplayName, emailAddress));
                //}
                //message.Subject = messageBuilder.Subject;
                //message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                //{
                //    Text = messageBuilder.Body
                //};

                //using (var client = new MailKit.Net.Smtp.SmtpClient())
                //{
                //    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //    client.CheckCertificateRevocation = false;
                //    client.Connect("mail5011.site4now.net", 587, SecureSocketOptions.Auto);
                //    //SMTP server authentication if needed
                //    client.Authenticate(From, Pwd);

                //    client.Send(message);

                //    client.Disconnect(true);
                //}

                //MailAddress from = new MailAddress(From);
                //foreach (var emailAddress in messageBuilder.To)
                //{
                //    MailAddress to = new MailAddress(emailAddress);
                //    MailMessage message = new MailMessage(from, to);
                //    message.Subject = messageBuilder.Subject;
                //    message.Body = messageBuilder.Body;
                //    SmtpClient client = new SmtpClient(server, 25)
                //    {
                //        Credentials = new NetworkCredential(From, Pwd),
                //        EnableSsl = false
                //    };
                //    client.Send(message);
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }

       
    }
}
