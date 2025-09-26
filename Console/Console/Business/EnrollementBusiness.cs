using Console.Models;
using eHealthApp.Services.Data;

namespace eHealthApp.Business
{
    public class EnrollementBusiness
    {
        private DataContext _context;
        private EnrollmentService _enrollementService;

        public EnrollementBusiness(DataContext context)
        {
            _context = context;
            _enrollementService = new EnrollmentService(_context);
        }

        public Enrollment CreateEnrollment(Enrollment enrollement)
        {
            _enrollementService.Save(enrollement);
            return enrollement;
        }

        public bool DeleteEnrollment(Enrollment enrollement)
        {
            _enrollementService.Delete(enrollement);
            return true;
        }
    }
}
