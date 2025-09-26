using Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services.Data
{
    public class MedicalClaimService : IDataService<MedicalClaim>
    {
        private readonly DataContext _context;
        public MedicalClaimService(DataContext context)
        {
            _context = context;
        }
        public void Save(MedicalClaim medicalClaim)
        {
            _context.MedicalClaims.Add(medicalClaim);
            _context.SaveChanges();
        }
        public void Update(MedicalClaim medicalClaim)
        {
            _context.MedicalClaims.Update(medicalClaim);
            _context.SaveChanges();
        }
        public void Delete(MedicalClaim medicalClaim)
        {
            _context.MedicalClaims.Remove(medicalClaim);
            _context.SaveChanges();
        }
        public MedicalClaim? GetById(int id) => _context.MedicalClaims.Find(id);
        public List<MedicalClaim> GetAll() => _context.MedicalClaims.ToList();
    }
}

