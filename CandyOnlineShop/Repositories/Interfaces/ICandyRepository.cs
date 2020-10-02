using CandyOnlineShop.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Interfaces
{
    public interface ICandyRepository
    {
        IEnumerable<Candy> GetAll();
        IEnumerable<Candy> GetOnSale();
        Candy GetById(int candyId);
        void Add(Candy candy);
        void Delete(Candy candy);
        void Update(Candy candy);
    }
}
