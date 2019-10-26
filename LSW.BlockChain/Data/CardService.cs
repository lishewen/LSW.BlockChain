using LSW.BlockChain.Models;
using LSW.BlockChain.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Data
{
    public class CardService
    {
        private readonly ICardSalesRepository _repository;
        public CardService(ICardSalesRepository repository) => _repository = repository;

        public async Task CreateCard(Card card)
        {
            await _repository.CreateCard(card);
        }
    }
}
