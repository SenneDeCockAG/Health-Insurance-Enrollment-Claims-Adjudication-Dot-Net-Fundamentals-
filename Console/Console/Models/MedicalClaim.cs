using eHealthApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MedicalClaim
{
    [Key]
    public int Id { get; set; }
    public string ClaimNumber { get; set; } = string.Empty;
    [ForeignKey(nameof(Member))]
    public int MemberId { get; set; }
    public DateTime DateOfService { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalBilled { get; set; }
    public decimal TotalAllowed { get; set; }

    public Member? Member { get; set; }
    public ICollection<ClaimLine> ClaimLines { get; set; } = [];
}
