using eHealthApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace eHealthApp.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }
        [Required]
        public Member Member { get; } = null!;
        [Required]
        [ForeignKey(nameof(Plan))]
        public int PlanId { get; set; }
        [Required]
        public Plan Plan { get; } = null!;
        public DateTime EnrollmentDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string? Status { get; set; }

        public Enrollment() { }

        public Enrollment(Member member, Plan plan, DateTime enrollmentDate)
        {
            Member = member;
            MemberId = member.Id;
            Plan = plan;
            PlanId = plan.Id;
            EnrollmentDate = enrollmentDate;
            TerminationDate = enrollmentDate.AddDays(365);
            Status = "ACTIVE";
        }
    }
}

