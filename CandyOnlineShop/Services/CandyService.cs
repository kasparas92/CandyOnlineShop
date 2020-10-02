using CandyOnlineShop.Models.Entity;
using CandyOnlineShop.Models.Interfaces;
using CandyOnlineShop.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Services
{
    public class CandyService : ICandyService
    {
        private readonly ICandyRepository _candyRepository;
        public CandyService(ICandyRepository candyRepository)
        {
            _candyRepository = candyRepository;
        }

        public void Add(Candy candy)
        {
            _candyRepository.Add(candy);
        }

        public void Delete(Candy candy)
        {
            _candyRepository.Delete(candy);
        }

        public IEnumerable<Candy> GetAll()
        {
            return _candyRepository.GetAll();
        }

        public Candy GetById(int candyId)
        {
            return _candyRepository.GetById(candyId);
        }

        public IEnumerable<Candy> GetOnSale()
        {
            return _candyRepository.GetOnSale();
        }

        public void Update(Candy candy)
        {
            _candyRepository.Update(candy);
        }
    }
}
