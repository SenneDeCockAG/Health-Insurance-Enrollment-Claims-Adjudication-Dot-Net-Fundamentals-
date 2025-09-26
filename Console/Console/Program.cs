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
System.Console.WriteLine("Static Program Finished\n" +
                         "Starting command line interpretation !.");
bool keepAlive = true;
while (keepAlive)
{
    System.Console.Write("> ");
    string input = System.Console.ReadLine()!;
    string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    InterpretCommand(inputArgs);
}
void InterpretCommand(string[] args)
    {
        if (args.Length == 0) return;

        string command = args[0].ToLower();

        switch (command)
        {
            case "help":
            System.Console.WriteLine("List of commande availabe : " +
                                     "  help : Gives a list of commande" +
                                     "  addAffiliate : Start the process for adding a new member ");
            break;
            case "addaffiliate":
                StartAffiliationProcess();
                break;
            case "listaffiliate":
                ListAffiliate();
                break;

            case "exit":
                keepAlive = false;
                break;
            default:
                System.Console.WriteLine($"Unknown command: {command}");
                break;
        }
    }

void StartAffiliationProcess()
{
    System.Console.WriteLine("=== Enrollment Process ===");

    System.Console.Write("Enter your first name: ");
    string firstName = System.Console.ReadLine()!;

    System.Console.Write("Enter your last name: ");
    string lastName = System.Console.ReadLine()!;

    DateTime birthday;
    while (true)
    {
        System.Console.Write("Enter your birthday (yyyy-MM-dd): ");
        string input = System.Console.ReadLine()!;

        if (DateTime.TryParse(input, out birthday))
            break;
        else
            System.Console.WriteLine("Invalid date format. Try again.");
    }
    Member addedMember = new Member { FirstName = firstName, LastName = lastName, DateOfBirth = birthday, EnrollmentStart = DateTime.Today };
    memberBusiness.CreateMember(addedMember);
    System.Console.WriteLine("\n--- Enrollment Summary ---");
    System.Console.WriteLine($"Name: {firstName} {lastName}");
    System.Console.WriteLine($"Birthday: {birthday:dddd, MMMM dd, yyyy}");
}

void ListAffiliate()
{
    List<Member> memberList = memberBusiness.ListMember();
    int index = 0;
    foreach (Member member in memberList)
    {
        System.Console.WriteLine($"{index}: {member.FirstName} {member.LastName}");
        index++;
    }

}
