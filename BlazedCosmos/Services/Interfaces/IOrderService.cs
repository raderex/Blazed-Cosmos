using BlazedCosmos.Models;
using System.Collections.Generic;

namespace BlazedCosmos.Services.Interfaces
{
    public interface IOrderService
    {
        List<CartItem> GetCart();
        void AddToCart(int productId);
        Order CreateOrder();
        void CompleteOrder(Order order);
    }
}
