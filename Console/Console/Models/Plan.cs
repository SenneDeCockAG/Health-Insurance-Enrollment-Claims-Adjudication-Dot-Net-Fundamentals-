
using System.ComponentModel.DataAnnotations;

namespace Console.Models;

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
    public bool HsaEligible { get; set; }
}
