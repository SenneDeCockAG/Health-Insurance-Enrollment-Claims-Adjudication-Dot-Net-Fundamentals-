using Console.Models;
using eHealthApp.Services.Data;

namespace eHealthApp.Business
{
    public class EnrollmentBusiness
    {
        private IDataService<Enrollment> _enrollementService;

        public EnrollmentBusiness(IDataService<Enrollment> ennrollmentService)
        {
            _enrollementService = ennrollmentService;
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
