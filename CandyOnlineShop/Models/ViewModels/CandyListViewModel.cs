using CandyOnlineShop.Models.Entity;
using System.Collections.Generic;

namespace CandyOnlineShop.Models.ViewModels
{
    public class CandyListViewModel
    {
        public string CurrentCategory { get; set; }
        public IEnumerable<Candy> Candies { get; set; }
    }
}
