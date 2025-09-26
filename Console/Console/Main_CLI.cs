//using System;

//class Program
//{
//    static void Main(string[] args)
//    {
//        if (args.Length > 0)
//        {
//            InterpretCommand(args);
//        }
//        else
//        {
//            Console.WriteLine("Welcome to the CLI. Type a command:");
//            while (true)
//            {
//                Console.Write("> ");
//                string input = Console.ReadLine()!!;
//                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//                InterpretCommand(inputArgs);
//            }
//        }
//    }

//    static void InterpretCommand(string[] args)
//    {
//        if (args.Length == 0) return;

//        string command = args[0].ToLower();

//        switch (command)
//        {
//            case "enroll":
//                EnrollmentProcess();
//                break;

//            default:
//                Console.WriteLine($"Unknown command: {command}");
//                break;
//        }
//    }

//    static void EnrollmentProcess()
//    {
//        Console.WriteLine("=== Enrollment Process ===");

//        Console.Write("Enter your first name: ");
//        string firstName = Console.ReadLine()!;

//        Console.Write("Enter your last name: ");
//        string lastName = Console.ReadLine()!;

//        DateTime birthday;
//        while (true)
//        {
//            Console.Write("Enter your birthday (yyyy-MM-dd): ");
//            string input = Console.ReadLine()!;

//            if (DateTime.TryParse(input, out birthday))
//                break;
//            else
//                Console.WriteLine("Invalid date format. Try again.");
//        }

//        Console.WriteLine("\n--- Enrollment Summary ---");
//        Console.WriteLine($"Name: {firstName} {lastName}");
//        Console.WriteLine($"Birthday: {birthday:dddd, MMMM dd, yyyy}");
//    }
//}