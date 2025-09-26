
namespace Console.Business;

public class BillingService : IBillingService
{
    public async Task<int> HttpHealthcheck()
    {
        System.Console.WriteLine("Checking Billing api...");
        await Task.Delay(1000);
        return 200;
    }
}
