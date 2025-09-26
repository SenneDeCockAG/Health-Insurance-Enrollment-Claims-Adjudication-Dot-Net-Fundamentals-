using System;
using eHealthApp.Business;
using eHealthApp.Models;
using eHealthApp.Services;
using eHealthApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eHealthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new DatabaseContext();
            var created = db.Database.EnsureCreated();
            Console.WriteLine($"EnsureCreated => {created}; DB at: {db.Database.GetDbConnection().DataSource}");

            // Business Object
            MemberBusiness memberBusiness = new MemberBusiness(db);
            EnrollementBusiness enrollmentBusiness = new EnrollementBusiness(db);
            PlanBusiness planBusiness = new PlanBusiness(db);

            // Add 
            Member member1 = new Member { FirstName = "Barack", LastName = "Obama", DateOfBirth = DateTime.Today, EnrollmentStart = DateTime.Today };
            memberBusiness.CreateMember(member1);

            // Add a plan
            Plan plan1 = new Plan { PlanCode = "120", PlanName = "Retraite à 67 ans", MonthlyPremium = 10, Deductible = 1000, OutOfPocketMax = 200};
            planBusiness.CreatePlan(plan1);

            // Enroll the member into the plan
            Enrollment enrollment1 = new Enrollment(member: member1, plan: plan1, enrollmentDate: DateTime.Today);
            enrollmentBusiness.CreateEnrollment(enrollment1);
        }
    }
}