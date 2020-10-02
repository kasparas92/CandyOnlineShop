using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using System.Collections.Generic;

namespace CandyOnlineShop.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CandyContext _candyContext;
        public CategoryRepository(CandyContext candyContext)
        {
            _candyContext = candyContext;
        }
        public IEnumerable<Category> GetAll()
        {
            var categories = _candyContext.Category;

            return categories;
        }
    }
}
