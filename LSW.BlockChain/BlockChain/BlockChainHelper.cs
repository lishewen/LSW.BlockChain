using LSW.BlockChain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.BlockChain
{
    public static class BlockChainHelper
    {
        public static void VerifyBlockChain(IList<CardSalesEntry> cardSalesEntries)
        {
            string previousHash = null;
            foreach (var entry in cardSalesEntries.OrderBy(c => c.Id))
            {
                var previousBlock = cardSalesEntries.SingleOrDefault(c => c.Id == entry.PreviousId);
                var blockText = BlockHelper.ConcatData(
                    entry.CardEntryId,
                    entry.CardNumber,
                    entry.Price,
                    entry.TransactionDate,
                    previousHash);

                var blockHash = HashHelper.Hash(blockText);

                // check current block hashes, and previous block hashes, since
                // it could have been modified in DB, ie checking the chain by two blocks at a time
                entry.IsValid = blockHash == entry.Hash && previousHash == previousBlock?.Hash;

                previousHash = blockHash;
            }
        }
    }
}
