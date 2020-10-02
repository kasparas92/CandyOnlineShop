using CandyOnlineShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Candy> CandiesOnSale { get; set; }
    }
}
