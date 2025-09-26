using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? PlanCode { get; set; }
        [Required]
        public string? PlanName { get; set; }
        public decimal MonthlyPremium { get; set; }
        public decimal Deductible { get; set; }
        public decimal OutOfPocketMax { get; set; }
    }
}
