
namespace Console.Business;

public interface IBillingService
{
    public Task<int> HttpHealthcheck();
}
