using Microsoft.AspNetCore.Mvc;
using PurchaseApi.Models;
using PurchaseApi.Services;

namespace PurchaseApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IShipmentService _shipmentService;

        public CheckoutController(
            ICartService cartService,
            IPaymentService paymentService,
            IShipmentService shipmentService
        )
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _shipmentService = shipmentService;
        }

        [HttpPost]
        public string ConductCheckout(Cart cart)
        {
            decimal totalSum = _cartService.TotalSum(cart.items);

            if (!_paymentService.Charge(totalSum, cart.card))
            {
                return "not charged";
            }
            
            string result = _shipmentService.Ship(cart.addressInfo, cart.items);

            return result;
        }
    }
}