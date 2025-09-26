// See https://aka.ms/new-console-template for more information
using Console.Business;
using Console.Infrastructure;
using Console.Models;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddScoped<IReporter, JsonReporter>()
    .AddScoped<IAnalytics, Analytics>()
    .AddScoped<IBillingService, BillingService>()
    .AddScoped<INotifier, SmsNotifier>()
    .BuildServiceProvider();


System.Console.WriteLine("Hello, World!");
using var db = new DataContext();
await db.Database.EnsureCreatedAsync();

if (!db.Members.Any())
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

System.Console.ReadKey();


