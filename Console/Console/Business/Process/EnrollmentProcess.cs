using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Business.Process
{
    public static class EnrollmentProcesses
    {
        public static void StartEnrollmentProcess()
        {
            Console.WriteLine("=== Enrollment Process ===");

            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine()!;

            DateTime birthday;
            while (true)
            {
                Console.Write("Enter your birthday (yyyy-MM-dd): ");
                string input = Console.ReadLine()!;

                if (DateTime.TryParse(input, out birthday))
                    break;
                else
                    Console.WriteLine("Invalid date format. Try again.");
            }

            Console.WriteLine("\n--- Enrollment Summary ---");
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Birthday: {birthday:dddd, MMMM dd, yyyy}");
        }
    }
}
