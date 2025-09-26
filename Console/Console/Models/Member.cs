using System.ComponentModel.DataAnnotations;

namespace Console.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? MembershipType { get; set; }
        public DateTime EnrollmentStart { get; set; }
        public DateTime EnrollmentEnd { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<MedicalClaim> MedicalClaims { get; set; } = new List<MedicalClaim>();
    }
}
