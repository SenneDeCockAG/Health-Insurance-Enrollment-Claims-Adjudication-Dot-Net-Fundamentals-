using Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services.Data
{
    public class ClaimLineService : IDataService<ClaimLine>
    {
        private readonly DataContext _context;
        public ClaimLineService(DataContext context)
        {
            _context = context;
        }
        public void Save(ClaimLine claimLine)
        {
            _context.ClaimLines.Add(claimLine);
            _context.SaveChanges();
        }
        public void Update(ClaimLine claimLine)
        {
            _context.ClaimLines.Update(claimLine);
            _context.SaveChanges();
        }
        public void Delete(ClaimLine claimLine)
        {
            _context.ClaimLines.Remove(claimLine);
            _context.SaveChanges();
        }
        public ClaimLine? GetById(int id) => _context.ClaimLines.Find(id);
        public List<ClaimLine> GetAll() => _context.ClaimLines.ToList();
    }
}
