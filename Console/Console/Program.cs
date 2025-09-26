// See https://aka.ms/new-console-template for more information
using Console.Business;
using Console.Infrastructure;
using Console.Models;
using eHealthApp.Business;
using eHealthApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddScoped<IReporter, JsonReporter>()
    .AddScoped<IAnalytics, Analytics>()
    .AddScoped<IBillingService, BillingService>()
    .AddScoped<INotifier, SmsNotifier>()
    .AddScoped<IDataService<Plan>, PlanService>()
    .BuildServiceProvider();


System.Console.WriteLine("Hello, World!");
using var db = new DataContext();
var created = await db.Database.EnsureCreatedAsync();
System.Console.WriteLine($"EnsureCreated => {created}; DB at: {db.Database.GetDbConnection().DataSource}");

if (!await db.Members.AnyAsync())
{
    db.Seed();
}
using var scope = services.CreateScope();
var jsonReporter = scope.ServiceProvider.GetService<IReporter>()!;
var xmlReporter = new XmlReporter();

jsonReporter.CreateMembersReport();
xmlReporter.CreateMembersReport();

var analytics = scope.ServiceProvider.GetService<IAnalytics>()!;
analytics.CreateAnalyticsReport();



// Business Object
MemberBusiness memberBusiness = new MemberBusiness(db);
EnrollementBusiness enrollmentBusiness = new EnrollementBusiness(db);
PlanBusiness planBusiness = new PlanBusiness(db);

// Add 
Member member1 = new Member { FirstName = "Barack", LastName = "Obama", DateOfBirth = DateTime.Today, EnrollmentStart = DateTime.Today };
memberBusiness.CreateMember(member1);

// Add a plan
Plan plan1 = new Plan { PlanCode = "120", PlanName = "Retraite à 67 ans", MonthlyPremium = 10, Deductible = 1000, OutOfPocketMax = 200 };
planBusiness.CreatePlan(plan1);

// Enroll the member into the plan
Enrollment enrollment1 = new Enrollment(member: member1, plan: plan1, enrollmentDate: DateTime.Today);
enrollmentBusiness.CreateEnrollment(enrollment1);
System.Console.WriteLine("Program finished.");
System.Console.ReadKey();
