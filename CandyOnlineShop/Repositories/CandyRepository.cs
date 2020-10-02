using CandyOnlineShop.Models.DataModels;
using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Repositories
{
    public class CandyRepository : ICandyRepository
    {
        private readonly CandyContext _candyContext;
        public CandyRepository(CandyContext candyContext)
        {
            _candyContext = candyContext;
        }

        public void Add(Candy candy)
        {
            _candyContext.Candy.Add(candy);
            _candyContext.SaveChanges();
        }

        public void Delete(Candy candy)
        {
            var shoppingCartItems = _candyContext.ShoppingCartItem.Where(x => x.Candy.Id == candy.Id).ToList();
            if(shoppingCartItems != null)
            {
                _candyContext.RemoveRange(shoppingCartItems);
            }
            _candyContext.Candy.Remove(candy);
            _candyContext.SaveChanges();
        }

        public IEnumerable<Candy> GetAll()
        {
            var candies = _candyContext.Candy.Include(c => c.Category);

            return candies;
        }

        public Candy GetById(int candyId)
        {
            var candy = _candyContext.Candy.Include(c => c.Category).FirstOrDefault(x => x.Id == candyId);

            return candy;
        }

        public IEnumerable<Candy> GetOnSale()
        {
            var candies = _candyContext.Candy.Include(c => c.Category).Where(p => p.IsOnSale);
            return candies;
        }

        public void Update(Candy candy)
        {
            _candyContext.Candy.Update(candy);
            _candyContext.SaveChanges();
        }
    }
}
