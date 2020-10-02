using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandyOnlineShop.Models.Services.Interfaces;
using CandyOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CandyOnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandyService _candyService;
        public HomeController(ICandyService candyService)
        {
            _candyService = candyService;
        }
        public IActionResult Index()
        {
            var candies = new HomeViewModel()
            {
                CandiesOnSale = _candyService.GetOnSale()
            };
            return View(candies);
        }
    }
}
