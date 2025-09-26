
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Console.Models
{
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

        [JsonIgnore]
        [XmlIgnore]
    public Member? Member { get; set; }
        public List<ClaimLine> ClaimLines { get; set; } = [];

        // public int ProviderId { get; set; }
        // public Provider Provider { get; set; }
        // public int EobId { get; set; }
        // public Eob Eob { get; set; }
    }
}

