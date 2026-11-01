using System.Globalization;
using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly ICartService _cartService;

        public ShipmentService(ICartService cartService)
        {
            _cartService = cartService;
        }

        public string Ship(AddressInfo info, IEnumerable<CartItem> items)
        {
            string sum = _cartService.TotalSum(items).ToString("F2", CultureInfo.InvariantCulture);
            
            return $"Shipped {_cartService.TotalQuantity(items)} items to  {info.City} on total sum {sum}$";
        }
    }
}
