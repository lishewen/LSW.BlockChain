using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Models
{
    public static class EFContextExtensions
    {
        public static void EnsureDbInitialized(this EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.CardEntries.AddRange(
                new Card
                {
                    Notes = "Sales 123",
                    CreateDate = DateTimeOffset.UtcNow
                },
                new Card
                {
                    Notes = "Sales 456",
                    CreateDate = DateTimeOffset.UtcNow
                },
                new Card
                {
                    Notes = "Sales 109",
                    CreateDate = DateTimeOffset.UtcNow
                }
            );

            context.SaveChanges();
        }
    }
}
