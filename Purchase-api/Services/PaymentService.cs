using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class PaymentService : IPaymentService
    {
        public bool Charge(decimal total, Card card)
        {
            return card.ValidTo >= DateTime.Now;
        }
    }
}
