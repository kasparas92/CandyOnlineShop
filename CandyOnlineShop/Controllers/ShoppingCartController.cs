using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using CandyOnlineShop.Models.Repositories.Interfaces;
using CandyOnlineShop.Models.Services.Interfaces;
using CandyOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ICandyService _candyService;
        public ShoppingCartController(ShoppingCart shoppingCart, ICandyService candyService)
        {
            _shoppingCart = shoppingCart;
            _candyService = candyService;
        }
        public IActionResult Index()
        {
            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCartItem = _shoppingCart.GetShoppingCartItems(),
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        public RedirectToActionResult AddToShoppingCart(int candyId)
        {
            var selectedCandy = _candyService.GetAll()
                .FirstOrDefault(x => x.Id == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.AddToCart(selectedCandy, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int candyId)
        {
            var selectedCandy = _candyService.GetAll()
                .FirstOrDefault(x => x.Id == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.RemoveFromCart(selectedCandy);
            }
            return RedirectToAction("Index");
        }
    }
}
