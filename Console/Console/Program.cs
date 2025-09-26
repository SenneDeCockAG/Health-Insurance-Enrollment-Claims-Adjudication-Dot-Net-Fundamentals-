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
    .AddScoped<DataContext>()
    .AddScoped<EnrollmentBusiness>()
    .AddScoped<MemberBusiness>()
    .AddScoped<PlanBusiness>()
    .AddScoped<IDataService<Plan>, PlanService>()
    .AddScoped<IDataService<Member>, MemberService>()
    .AddScoped<IDataService<Enrollment>, EnrollmentService>()
    .BuildServiceProvider();


System.Console.WriteLine("Hello, World!");
using var scope = services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<DataContext>();
await db.Database.EnsureDeletedAsync();
var created = await db.Database.EnsureCreatedAsync();
System.Console.WriteLine($"EnsureCreated => {created}; DB at: {db.Database.GetDbConnection().DataSource}");

if (!await db.Members.AnyAsync())
{
    db.Seed();
}

var jsonReporter = scope.ServiceProvider.GetService<IReporter>()!;
var xmlReporter = new XmlReporter(scope.ServiceProvider.GetService<IDataService<Member>>()!);

jsonReporter.CreateMembersReport();
xmlReporter.CreateMembersReport();

var analytics = scope.ServiceProvider.GetService<IAnalytics>()!;
analytics.CreateAnalyticsReport();



// Business Object
var enrollmentBusiness = scope.ServiceProvider.GetService<EnrollmentBusiness>()!;
var memberBusiness = scope.ServiceProvider.GetService<MemberBusiness>()!;
var planBusiness = scope.ServiceProvider.GetService<PlanBusiness>()!;

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

