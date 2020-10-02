using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IOrderService orderService, ShoppingCart shoppingCart)
        {
            _orderService = orderService;
            _shoppingCart = shoppingCart;
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var s = _shoppingCart.GetShoppingCartItems();
            if(s.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty. Please add candies you idiot!!!!!!!!!!!!!!");
            }
            else if(ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        [HttpGet]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutMessage = "Thank you for your order and your money. These candies are fake. Enjoy!!!!";
            return View();
        }
    }
}
