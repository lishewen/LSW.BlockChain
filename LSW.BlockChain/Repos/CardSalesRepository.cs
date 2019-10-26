using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSW.BlockChain.BlockChain;
using LSW.BlockChain.Models;
using Microsoft.EntityFrameworkCore;

namespace LSW.BlockChain.Repos
{
    public class CardSalesRepository : ICardSalesRepository
    {
        private readonly EFContext _context;
        public CardSalesRepository(EFContext context) => _context = context;
        public async Task CreateCard(Card cardEntry)
        {
            if (cardEntry == null)
                throw new ArgumentNullException(nameof(cardEntry));

            cardEntry.CreateDate = DateTimeOffset.UtcNow;

            _context.CardEntries.Add(cardEntry);

            await _context.SaveChangesAsync();
        }

        public async Task CreateCardSale(CardSalesEntry cardSalesEntry)
        {
            if (cardSalesEntry == null)
                throw new ArgumentNullException(nameof(cardSalesEntry));

            var cardSalesEntries = await _context.CardSalesEntries.Where(c => c.CardEntryId == cardSalesEntry.CardEntryId).ToListAsync();

            BlockChainHelper.VerifyBlockChain(cardSalesEntries);
            if (cardSalesEntries.Any(c => !c.IsValid))
            {
                throw new InvalidOperationException("Block Chain was invalid");
            }

            string previousBlockHash = null;
            if (cardSalesEntries.Any())
            {
                var previousCarSalesEntry = cardSalesEntries.Last();
                cardSalesEntry.PreviousId = previousCarSalesEntry.Id;
                previousBlockHash = previousCarSalesEntry.Hash;
            }

            var blockText = BlockHelper.ConcatData(cardSalesEntry.CardEntryId, cardSalesEntry.CardNumber,
                cardSalesEntry.Price, cardSalesEntry.TransactionDate, previousBlockHash);
            cardSalesEntry.Hash = HashHelper.Hash(blockText);

            _context.CardSalesEntries.Add(cardSalesEntry);

            await _context.SaveChangesAsync();
        }

        public async Task<Card> GetCard(int id)
        {
            var car = await _context.CardEntries.Include(c => c.CardSalesEntries).SingleOrDefaultAsync(c => c.Id == id);

            if (car != null)
            {
                BlockChainHelper.VerifyBlockChain(car.CardSalesEntries);
            }

            return car;
        }

        public async Task<IList<Card>> GetCards()
        {
            return await _context.CardEntries.ToListAsync();
        }
    }
}
