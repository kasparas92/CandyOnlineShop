using CandyOnlineShop.Models.Entity;
using System.Collections.Generic;

namespace CandyOnlineShop.Models.Services.Interfaces
{
    public interface ICandyService
    {
        IEnumerable<Candy> GetAll();
        IEnumerable<Candy> GetOnSale();
        Candy GetById(int candyId);
        void Add(Candy candy);
        void Delete(Candy candy);
        void Update(Candy candy);
    }
}
