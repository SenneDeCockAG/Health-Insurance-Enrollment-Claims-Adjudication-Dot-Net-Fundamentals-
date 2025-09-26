using Console.Models;
using eHealthApp.Services.Data;

namespace eHealthApp.Business
{
    public class MemberBusiness
    {
        private DataContext _context;
        private MemberService _service;

        public MemberBusiness(DataContext context)
        {
            _context = context;
            _service = new MemberService(_context);
        }

        public Member CreateMember(Member member)
        {
            _service.Save(member);
            return member;
        }

        public bool DeleteMember(Member member)
        {
            _service.Delete(member);
            return true;
        }
    }
}
