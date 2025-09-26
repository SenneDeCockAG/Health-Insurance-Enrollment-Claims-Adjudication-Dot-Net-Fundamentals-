using Console.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eHealthApp.Models
{
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Npi { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public bool InNetwork { get; set; }
        public List<MedicalClaim> MedicalClaims { get; set; } = new List<MedicalClaim>();
    }

}
