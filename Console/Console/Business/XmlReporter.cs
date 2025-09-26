
using Console.Infrastructure;
using Console.Models;
using eHealthApp.Services.Data;
using System.Xml.Serialization;

namespace Console.Business;

public class XmlReporter : IReporter
{
    public static readonly string FILEPATH = Path.Combine("..", "..", "..", "report.xml");

    private readonly IDataService<Member> _memberService;

    public XmlReporter(IDataService<Member> memberService)
    {
        _memberService = memberService;
    }
    public bool CreateMembersReport()
    {
        var members = _memberService.GetAll();
        var serializer = new XmlSerializer(typeof(List<Member>));
        using var fs = new FileStream(FILEPATH, FileMode.Create, FileAccess.Write, FileShare.None);
        serializer.Serialize(fs, members);
        return true;
    }
}
