using Microsoft.AspNetCore.Mvc;
using BlazedCosmos.Models;
using BlazedCosmos.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using BlazedCosmos.Helpers;

namespace BlazedCosmos.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject DbContext
        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // Display cart items
        public IActionResult Index()
        {
            var cart = GetCart();
            // Fetch product details for each cart item
            foreach (var item in cart)
            {
                item.Product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
            }
            return View(cart);
        }

        // Add a product to the cart
        [HttpPost]
        public IActionResult Add(int productId)
        {
            var cart = GetCart();
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);
                if (existingItem == null)
                {
                    // Add new item to cart
                    cart.Add(new CartItem { ProductId = productId, Quantity = 1 });
                }
                else
                {
                    // Increase quantity of existing item
                    existingItem.Quantity++;
                }

                // Save cart to session
                SaveCart(cart);
            }

            return Json(new { success = true });  // Return a success response to the AJAX call
        }

        // Remove item from cart
        [HttpPost]
        public IActionResult Remove(int productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.FirstOrDefault(c => c.ProductId == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        // Checkout process (placeholder for now)
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (cart.Any())
            {
                // Checkout logic here
                // You can create an order, process payment, etc.
                return View(); // Placeholder for actual checkout view
            }

            return RedirectToAction("Index");
        }

        // Helper method to get the cart from the session
        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart");
            return cart ?? new List<CartItem>();
        }

        // Helper method to save the cart to session
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}
