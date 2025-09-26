using eHealthApp.Models;
using eHealthApp.Services;
using eHealthApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Business
{
    public class MemberBusiness
    {
        private DatabaseContext _context;
        private MemberService _service;

        public MemberBusiness(DatabaseContext context)
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
