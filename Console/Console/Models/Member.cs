using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Sate {  get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime EnrollementStart { get; set; }
        public DateTime EnrollementEnd { get; set; }
    

    }
}
