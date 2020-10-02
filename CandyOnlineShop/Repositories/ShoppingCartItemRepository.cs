using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly CandyContext _candyContext;
        public ShoppingCartItemRepository(CandyContext candyContext)
        {
            _candyContext = candyContext;
        }
        public void AddToCart(Candy candy, int amount, string shoppingCartId)
        {
            var shoppingCartItem = _candyContext.ShoppingCartItem
                .SingleOrDefault(x => x.Candy.Id == candy.Id && x.ShoppingCartId == shoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = shoppingCartId,
                    Candy = candy,
                    Amount = amount
                };

                _candyContext.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _candyContext.SaveChanges();
        }

        public void ClearCart(string shoppingCartId)
        {
            var shoppingCartItems = _candyContext.ShoppingCartItem
                .Where(x => x.ShoppingCartId == shoppingCartId);

            _candyContext.ShoppingCartItem.RemoveRange(shoppingCartItems);
            _candyContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems(string shoppingCartId)
        {
            return _candyContext.ShoppingCartItem
                .Where(x => x.ShoppingCartId == shoppingCartId)
                .Include(x => x.Candy).ToList();
        }

        public decimal GetShoppingCartTotal(string shoppingCartId)
        {
            return _candyContext.ShoppingCartItem
                .Where(x => x.ShoppingCartId == shoppingCartId)
                .Select(x => x.Candy.Price * x.Amount)
                .Sum();
        }

        public int RemoveFromCart(Candy candy, string shoppingCartId)
        {
            var shoppingCartItem = _candyContext.ShoppingCartItem
                .SingleOrDefault(s => s.Candy.Id == candy.Id 
                                && s.ShoppingCartId == shoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _candyContext.ShoppingCartItem.Remove(shoppingCartItem);
                }
            }

            _candyContext.SaveChanges();

            return localAmount;
        }
    }
}
