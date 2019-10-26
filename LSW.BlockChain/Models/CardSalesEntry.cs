using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LSW.BlockChain.Models
{
    public class CardSalesEntry : IBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CardEntryId")]
        public int CardEntryId { get; set; }
        [ForeignKey("Id")]
        public int? PreviousId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset TransactionDate { get; set; }
        [Required]
        [ValidateNever]
        public string Hash { get; set; }
        [NotMapped]
        public bool IsValid { get; set; }

        public virtual CardSalesEntry Previous { get; set; }
    }
}
