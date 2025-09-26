using eHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services.Data
{
    public class PlanService
    {
        private readonly DatabaseContext _context;
        public PlanService(DatabaseContext context)
        {
            _context = context;
        }
        public void Save(Plan plan)
        {
            _context.Plans.Add(plan);
            _context.SaveChanges();
        }
        public void Update(Plan plan)
        {
            _context.Plans.Update(plan);
            _context.SaveChanges();
        }
        public void Delete(Plan plan)
        {
            _context.Plans.Remove(plan);
            _context.SaveChanges();
        }
        public Plan? GetById(int id) => _context.Plans.Find(id);
        public List<Plan> GetAll() => _context.Plans.ToList();
    }
}
