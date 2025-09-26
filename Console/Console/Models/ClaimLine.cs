using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ClaimLine
{
    [Key]
    public int Id { get; set; }
    [ForeignKey(nameof(MedicalClaim))]
    [Required]
    public int MedicalClaimId { get; set; }
    public string CptCode { get; set; } = string.Empty;
    public string Icd10Code { get; set; } = string.Empty;
    public decimal BilledAmount { get; set; }
    public decimal AllowedAmount { get; set; }
    public decimal CopayApplied { get; set; }
    public decimal CoinsuranceApplied { get; set; }
    public decimal DeductibleApplied { get; set; }
    public decimal PlanPaidAmount { get; set; }
    public decimal MemberResponsibility { get; set; }
    public MedicalClaim? MedicalClaim { get; set; }
}
