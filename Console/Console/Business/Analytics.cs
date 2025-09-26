using Console.Business;

public class Analytics : IAnalytics
{
    private readonly MemberService _memberService;

    public Analytics()
    {
        _memberService = new MemberService();
    }

    public bool CreateAnalyticsReport()
    {
        var members = _memberService.GetAll();

        var averageClaimCost = members
            .SelectMany(m => m.MedicalClaims)
            .Average(c => c.TotalBilled);

        System.Console.WriteLine($"Average Claim Cost: ${averageClaimCost:F2}");

        var providerUtilization = members
            .SelectMany(m => m.MedicalClaims)
            .GroupBy(c => c.Status)
            .Select(g => new { Status = g.Key, Average = g.Average(mc => mc.TotalBilled) });

        System.Console.WriteLine("\nProvider Utilization:");
        foreach (var provider in providerUtilization)
        {
            System.Console.WriteLine($"Status {provider.Status}:  ${provider.Average:F2} Average billed per status(s)");
        }

        var memberOutOfPocket = members
            .Select(m => new
            {
                m.FirstName,
                m.LastName,
                Total = m.MedicalClaims
                    .SelectMany(c => c.ClaimLines)
                    .Sum(cl => cl.MemberResponsibility)
            });

        System.Console.WriteLine("\nMember Out-of-Pocket Totals:");
        foreach (var member in memberOutOfPocket)
        {
            System.Console.WriteLine($"{member.FirstName} {member.LastName}: ${member.Total:F2}");
        }

        return true;
    }
}