using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.BlockChain
{
    public static class BlockHelper
    {
        public static string ConcatData(int cardId, string cardNumber, decimal price, DateTimeOffset transactionDate, string previousBlockHash)
        {
            var formattedPrice = price.ToString("F");
            var formattedDate = transactionDate.ToString("yyyy-MM-dd");
            return $"{cardId}{cardNumber}{formattedPrice}{formattedDate}{previousBlockHash}";
        }
    }
}
