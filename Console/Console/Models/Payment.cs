using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(PremiumInvoice))]
        public int PremiumInvoiceId { get; set; }

        public PremiumInvoice PremiumInvoice { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaidAt { get; set; }

        [Required]
        public string Method { get; set; } = "BANK_TRANSFER";
        public string? Reference { get; set; }
    }
}