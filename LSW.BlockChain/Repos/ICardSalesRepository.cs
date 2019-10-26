using LSW.BlockChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Repos
{
    public interface ICardSalesRepository
    {
        Task<IList<Card>> GetCards();
        Task<Card> GetCard(int id);
        Task CreateCard(Card cardEntry);
        Task CreateCardSale(CardSalesEntry cardSalesEntry);
    }
}
