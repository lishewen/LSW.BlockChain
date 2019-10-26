using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Models
{
    public class Card : IBlockChain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset CreateDate { get; set; }

        public virtual IList<CardSalesEntry> CardSalesEntries { get; set; }
    }
}
