using Microsoft.AspNetCore.Mvc;
using BlazedCosmos.Services.Interfaces;
using BlazedCosmos.Models;
using System;

namespace BlazedCosmos.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Cart()
        {
            var cart = _orderService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            _orderService.AddToCart(productId);
            return RedirectToAction("Cart");
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
                try
                {
                    _orderService.CompleteOrder(order);
                    return RedirectToAction("ThankYou");
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(order);
                }
            }
            return View(order);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}