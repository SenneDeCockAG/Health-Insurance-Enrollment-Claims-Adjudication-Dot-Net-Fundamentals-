
using Console.Infrastructure;
using System.Text.Json;

namespace Console.Business;

public class JsonReporter : IReporter
{
    public static readonly string FILEPATH = Path.Combine("..", "..", "..", "report.json");
    private readonly MemberService _memberService;

    public JsonReporter()
    {
        _memberService = new MemberService();
    }

    public bool CreateMembersReport()
    {
        var members = _memberService.GetAll();

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(members, options);
        File.WriteAllText(FILEPATH, json);
        return true;
    }
}
