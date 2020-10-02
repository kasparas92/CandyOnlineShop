using CandyOnlineShop.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetAll().OrderBy(x => x.Name);
            return View(categories);
        }
    }
}
