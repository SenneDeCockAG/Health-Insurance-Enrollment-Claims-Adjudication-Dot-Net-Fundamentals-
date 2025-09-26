
using Console.Models;
using Microsoft.EntityFrameworkCore;

namespace eHealthApp.Services.Data;
public class MemberService : IDataService<Member>
{
    private readonly DataContext _context;
    public MemberService(DataContext context)
    {
        _context = context;
    }
    public void Save(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
    }
    public void Update(Member member)
    {
        _context.Members.Update(member);
        _context.SaveChanges();
    }
    public void Delete(Member member)
    {
        _context.Members.Remove(member);
        _context.SaveChanges();
    }
    public Member? GetById(int id) => _context.Members.Find(id);
    public List<Member> GetAll() => _context.Members
        .Include(m => m.MedicalClaims)
        .ThenInclude(mc => mc.ClaimLines)
        .Include(m => m.Enrollments)
        .ThenInclude(e => e.Plan)
        .ToList();
}





/*public List<Member> SearchByName(string name) =>
    _context.Members
            .Where(m => m.FirstName != null && m.FirstName.Contains(name) ||
                        m.LastName != null && m.LastName.Contains(name))
            .ToList();
public List<Member> GetByMembershipType(string membershipType) =>
    _context.Members
            .Where(m => m.MembershipType == membershipType)
            .ToList();
public List<Member> GetByEnrollmentDateRange(DateTime start, DateTime end) =>
    _context.Members
            .Where(m => m.EnrollmentStart >= start && m.EnrollmentEnd <= end)
            .ToList();
public List<Member> GetByCity(string city) =>
    _context.Members
            .Where(m => m.City == city)
            .ToList();
public List<Member> GetByState(string state) =>
    _context.Members
            .Where(m => m.State == state)
            .ToList();
public List<Member> GetByCountry(string country) =>
    _context.Members
            .Where(m => m.Country == country)
            .ToList();
public List<Member> GetByAgeRange(int minAge, int maxAge)
{
    var today = DateTime.Today;
    var minDateOfBirth = today.AddYears(-maxAge - 1).AddDays(1);
    var maxDateOfBirth = today.AddYears(-minAge);
    return _context.Members
                   .Where(m => m.DateOfBirth >= minDateOfBirth && m.DateOfBirth <= maxDateOfBirth)
                   .ToList();
}
public List<Member> GetByEmailDomain(string domain) =>
    _context.Members
            .Where(m => m.Email != null && m.Email.EndsWith("@" + domain))
            .ToList();
public List<Member> GetAllMemberOfPlan(Plan plan) =>
    _context.Enrollments
            .Where(e => e.PlanId == plan.Id && e.Status == "Active")
            .Select(e => e.Member)
            .ToList();*/