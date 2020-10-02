using CandyOnlineShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
    }
}
