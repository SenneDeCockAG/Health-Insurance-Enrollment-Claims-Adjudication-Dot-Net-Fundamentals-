using eHealthApp.Business.Process;
using eHealthApp.Services;
using System;
class Program
{
    static bool keepAlive = true;
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            InterpretCommand(args);
        }
        else
        {
            Console.WriteLine("Welcome to the CLI. Type a command:");
            while (keepAlive)
            {
                Console.Write("> ");
                string input = Console.ReadLine()!;
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                InterpretCommand(inputArgs);
            }
        }
    }

    static void InterpretCommand(string[] args)
    {
        if (args.Length == 0) return;

        string command = args[0].ToLower();

        switch (command)
        {
            case "enroll":
                EnrollmentProcesses.StartEnrollmentProcess();
                break;

            case "exit":
                keepAlive = false;
                break;
            default:
                Console.WriteLine($"Unknown command: {command}");
                break;
        }
    }

    
}