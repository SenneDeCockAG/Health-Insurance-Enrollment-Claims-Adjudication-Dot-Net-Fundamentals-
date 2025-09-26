using Console.Models;

namespace Console.Business;

public class EmailNotifier : INotifier
{
    public async Task Notify(Member member)
    {
        System.Console.Write($"Notifying {member.FirstName} by mail");
        await Task.Delay(200);
        System.Console.WriteLine($"Notified {member.FirstName}");
    }
}
