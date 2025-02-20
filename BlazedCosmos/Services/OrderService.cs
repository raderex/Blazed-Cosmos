using BlazedCosmos.Models;
using BlazedCosmos.Data;
using Microsoft.Extensions.Options;
using BlazedCosmos.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BlazedCosmos.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly AppSettings _appSettings;
        private List<CartItem> _cart = new List<CartItem>();

        public OrderService(AppDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public List<CartItem> GetCart()
        {
            return _cart;
        }

        public void AddToCart(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                var cartItem = _cart.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem == null)
                {
                    _cart.Add(new CartItem { ProductId = productId, Quantity = 1 });
                }
                else
                {
                    cartItem.Quantity++;
                }
            }
        }

        public Order CreateOrder()
        {
            var order = new Order { OrderDate = DateTime.Now, Items = _cart, TotalAmount = _cart.Sum(ci => _context.Products.Find(ci.ProductId).Price * ci.Quantity) };
            return order;
        }

        public void CompleteOrder(Order order)
        {
            if (_appSettings.FeatureFlags.EnableNewCheckout)
            {
                // New checkout logic
                _context.Orders.Add(order);
                _context.SaveChanges();
                _cart.Clear();
            }
            else
            {
                // Old checkout logic (if needed)
                throw new InvalidOperationException("Checkout feature is disabled.");
            }
        }
    }
}