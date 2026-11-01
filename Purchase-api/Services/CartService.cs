using PurchaseApi.Models;

namespace PurchaseApi.Services
{
    public class CartService : ICartService
    {
        public decimal TotalSum(IEnumerable<CartItem> items)
        {
            decimal totalSum = items.Sum((item) => item.Price * item.Quantity);

            return totalSum;
        }

        public int TotalQuantity(IEnumerable<CartItem> items)
        {
            int totalQuantity = items.Sum((item) => item.Quantity);
            
            return totalQuantity;
        }
    }
}
