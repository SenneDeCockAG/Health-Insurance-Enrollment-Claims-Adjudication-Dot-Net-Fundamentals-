
using Console.Models;

namespace Console.Business;

public interface INotifier
{
    Task Notify(Member member);
}
