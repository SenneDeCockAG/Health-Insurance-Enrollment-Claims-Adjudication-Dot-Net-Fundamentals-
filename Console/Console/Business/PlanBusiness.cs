using Console.Models;
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
    public class PlanBusiness
    {
        private DataContext _context;
        private PlanService _planService;

        public PlanBusiness(DataContext context)
        {
            _context = context;
            _planService = new PlanService(_context);
        }

        public Plan CreatePlan(Plan plan)
        {
            _planService.Save(plan);
            return plan;
        }

        public bool DeletePlan(Plan plan)
        {
            _planService.Delete(plan);
            return true;
        }
    }
}
