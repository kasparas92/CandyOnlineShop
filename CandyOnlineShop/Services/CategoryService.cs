using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using CandyOnlineShop.Models.Services.Interfaces;
using System.Collections.Generic;

namespace CandyOnlineShop.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}
