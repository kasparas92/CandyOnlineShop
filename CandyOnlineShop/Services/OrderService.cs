using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Repositories.Interfaces;
using CandyOnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
        }
    }
}
