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
    public class EnrollementBusiness
    {
        private DatabaseContext _context;
        private EnrollmentService _enrollementService;

        public EnrollementBusiness(DatabaseContext context)
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
