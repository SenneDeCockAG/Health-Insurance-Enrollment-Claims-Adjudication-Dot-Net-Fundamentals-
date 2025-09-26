using Console.Models;
using eHealthApp.Services.Data;

namespace eHealthApp.Business
{
    public class MemberBusiness
    {
        private IDataService<Member> _service;

        public MemberBusiness(IDataService<Member> dataService)
        {
            _service = dataService;
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
