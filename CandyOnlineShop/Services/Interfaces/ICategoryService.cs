using CandyOnlineShop.Models.Entity;
using System.Collections.Generic;

namespace CandyOnlineShop.Models.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}
