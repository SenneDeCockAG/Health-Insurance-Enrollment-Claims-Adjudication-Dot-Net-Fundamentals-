
using Console.Infrastructure;
using Console.Models;
using eHealthApp.Services.Data;
using System.Text.Json;

namespace Console.Business;

public class JsonReporter : IReporter
{
    public static readonly string FILEPATH = Path.Combine("..", "..", "..", "report.json");
    private readonly IDataService<Member> _memberService;

    public JsonReporter(IDataService<Member> memberService)
    {
        _memberService = memberService;
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
