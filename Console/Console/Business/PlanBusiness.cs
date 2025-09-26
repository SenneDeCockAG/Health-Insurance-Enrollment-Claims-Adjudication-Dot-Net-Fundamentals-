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
        private IDataService<Plan> _planService;

        public PlanBusiness(IDataService<Plan> context)
        {
            _planService = context;
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
