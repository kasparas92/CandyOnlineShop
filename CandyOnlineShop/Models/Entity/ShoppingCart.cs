using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyOnlineShop.Models.Entity
{
    public class ShoppingCart
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        public ShoppingCart(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public string Id { get; set; }
        public List<ShoppingCartItem> Items { get; set; }

        public void AddToCart(Candy candy, int amount)
        {
            _shoppingCartItemRepository.AddToCart(candy, amount, Id);
        }

        public void ClearCart()
        {
            _shoppingCartItemRepository.ClearCart(Id);
        }

        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var repo = serviceProvider.GetService<IShoppingCartItemRepository>();
            var cartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();
            session.SetString("ShoppingCartId", cartId);
            return new ShoppingCart(repo) { Id = cartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _shoppingCartItemRepository.GetShoppingCartItems(Id);
        }

        public decimal GetShoppingCartTotal()
        {
            return _shoppingCartItemRepository.GetShoppingCartTotal(Id);
        }

        public int RemoveFromCart(Candy candy)
        {
            return _shoppingCartItemRepository.RemoveFromCart(candy, Id);
        }
    }
}
