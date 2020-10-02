using CandyOnlineShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Repositories.Interfaces
{
    public interface IShoppingCartItemRepository
    {
        void AddToCart(Candy candy, int amount, string shoppingCartId);
        int RemoveFromCart(Candy candy, string shoppingCartId);
        List<ShoppingCartItem> GetShoppingCartItems(string shoppingCartId);
        void ClearCart(string shoppingCartId);
        decimal GetShoppingCartTotal(string shoppingCartId);
    }
}
