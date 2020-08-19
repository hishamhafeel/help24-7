using Help247.Common.Mailer;
using Help247.Service.BO.Lookup;
using Microsoft.Extensions.Configuration;

namespace Help247.Service.Services.Lookup
{
    public class LookUpService : ILookUpService
    {
        private readonly IConfiguration configuration;

        public LookUpService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendSubscriptionMail(string email)
        {
            var messageBuilder = new EmailBuilder(configuration)
            {
                To = new[] { email },
                Subject = "Welcome To Help 24/7",
                IsBodyHtml = true,
                Body = $"Hi {email} , Thank you for your interest in our service from Help 24/7. " +
                        $"We will keep you updated on the latest news and helps.<br/>" +
                        $"Happy Help!!!"

            };
            EmailBuilder.SendEmail(messageBuilder);
        }

        public void SendContactUsMail(ContactUsBO model)
        {
            var messageBuilder = new EmailBuilder(configuration)
            {
                To = new[] { configuration["Email:credentials:username"] },
                Subject = $"Contact Us Mail from {model.Name}",
                IsBodyHtml = true,
                Body = $"{model.Name} ({model.Email}) has contacted us with the following message: " +
                        $"{model.Description}" 

            };
            EmailBuilder.SendEmail(messageBuilder);
        }
    }
}
