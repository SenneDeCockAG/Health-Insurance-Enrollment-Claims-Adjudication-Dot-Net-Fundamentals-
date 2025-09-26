using Console.Models;

namespace eHealthApp.Services.Data
{
    public class EnrollmentService : IDataService<Enrollment>
    {
        private readonly DataContext _context;
        public EnrollmentService(DataContext context)
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
