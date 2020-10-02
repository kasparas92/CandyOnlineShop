using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Services.Interfaces;
using CandyOnlineShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CandyOnlineShop.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyService _candyService;
        private readonly ICategoryService _categoryService;
        public CandyController(ICandyService candyService, ICategoryService categoryService)
        {
            _candyService = candyService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;
            if(string.IsNullOrEmpty(category))
            {
                candies = _candyService.GetAll().OrderBy(x => x.Id);
                currentCategory = "All Candies";
            }
            else
            {
                candies = _candyService.GetAll().Where(x => x.Category.Name == category).OrderBy(x => x.Id);
                currentCategory = _candyService.GetAll().FirstOrDefault(c => c.Category.Name == category).Category.Name;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            });
        }
        public IActionResult Details(int id)
        {
            
            var candy = _candyService.GetById(id);
            if (candy == null)
            {
                return NotFound();
            }
            return View(candy);
        }
        [HttpGet]
        public IActionResult Add(string name)
        {
            var category = _categoryService.GetAll().FirstOrDefault(x => x.Name == name);
            var candy = new Candy();
            candy.Category = category;
            candy.CategoryId = category.Id;
            return View(candy);
        }
        [HttpPost]
        public IActionResult Add(Candy candy)
        {
            var name = candy.Category.Name;
            candy.Category = null;
            if (candy.ImageThumbnailUrl.Contains("\\\\"))
            {
                candy.ImageThumbnailUrl = candy.ImageThumbnailUrl.Replace("\\\\", "\\");
            }
            if (candy.ImageUrl.Contains("\\\\"))
            {
                candy.ImageUrl = candy.ImageUrl.Replace("\\\\", "\\");
            }
            _candyService.Add(candy);

            return RedirectToAction("Index", new { category = name });
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var candy = _candyService.GetById(id);
            _candyService.Delete(candy);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int candyId)
        {
            var candy = _candyService.GetById(candyId);
            return View(candy);
        }
        [HttpPost]
        public IActionResult Update(Candy candy)
        {
            var name = candy.Category.Name;
            candy.Category = null;
            _candyService.Update(candy);
            return RedirectToAction("Index", new { category = name});
        }
    }
}
