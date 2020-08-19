using Help247.Service.BO.Lookup;
using System.Threading.Tasks;

namespace Help247.Service.Services.Lookup
{
    public interface ILookUpService
    {
        void SendSubscriptionMail(string email);
        void SendContactUsMail(ContactUsBO model);
    }
}
