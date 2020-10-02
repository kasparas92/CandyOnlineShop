using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CandyContext _candyContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(CandyContext candyContext, ShoppingCart shoppingCart)
        {
            _candyContext = candyContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.Total = _shoppingCart.GetShoppingCartTotal();
            _candyContext.Order.Add(order);
            _candyContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            
            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    Price = item.Candy.Price,
                    CandyId = item.Candy.Id,
                    OrderId = order.Id
                };
                _candyContext.OrderDetail.Add(orderDetail);
            }
            _candyContext.SaveChanges();
        }
    }
}
