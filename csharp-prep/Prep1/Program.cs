// program by Anderson OKai

using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Output the formatted name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
