using Microsoft.AspNetCore.Mvc;
using BlazedCosmos.Services.Interfaces;
using BlazedCosmos.Models;

namespace BlazedCosmos.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Display the cart
        public IActionResult Cart()
        {
            var cart = _orderService.GetCart(); // Get the current cart from OrderService
            return View(cart);
        }

        // Add product to cart (via the service)
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            _orderService.AddToCart(productId); // Add to cart through the service
            return RedirectToAction("Cart"); // Redirect to the cart view
        }

        public IActionResult Checkout()
        {
            var order = _orderService.CreateOrder();
            return View(order);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.CompleteOrder(order);
                return RedirectToAction("ThankYou");
            }
            return View(order);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
