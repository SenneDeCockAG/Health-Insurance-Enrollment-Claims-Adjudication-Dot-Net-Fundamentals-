using eHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services.Data
{
    public class EnrollmentService
    {
        private readonly DatabaseContext _context;
        public EnrollmentService(DatabaseContext context)
        {
            _context = context;
        }
        public void Save(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }
        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }
        public void Delete(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
        }
        public Enrollment? GetById(int id) => _context.Enrollments.Find(id);
        public List<Enrollment> GetAll() => _context.Enrollments.ToList();
    }
}
