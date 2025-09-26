
using Console.Models;

namespace Console.Business;

public class SmsNotifier : INotifier
{
    public async Task Notify(Member member)
    {
        System.Console.Write($"Notifying {member.FirstName} by SMS");
        await Task.Delay(200);
        System.Console.WriteLine($"Notified {member.FirstName}");

    }
}
