using Console.Models;
using Microsoft.EntityFrameworkCore;
namespace Console.Business;

public class MemberService
{
    public List<Member> GetAll()
    {
        using var db = new DataContext();
        return db.Members
            .Include(m => m.MedicalClaims)
            .ThenInclude(m => m.ClaimLines)
            .Include(m => m.Enrollments)
            .ThenInclude(m => m.Plan)
            .ToList();
    }
}
