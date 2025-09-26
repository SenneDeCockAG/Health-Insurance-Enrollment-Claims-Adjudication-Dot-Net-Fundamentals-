using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Models
{
    public class PremiumInvoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        [Required]
        public DateTime PeriodStart { get; set; }

        [Required]
        public DateTime PeriodEnd { get; set; }

        [Required]
        public decimal AmountDue { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public string Status { get; set; } = "PENDING";
    }
}