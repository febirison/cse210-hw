//Code By Anderson Okai

using System;

class Program
{
    static void Main(string[] args)
    {
        // Call function to display welcome message
        DisplayWelcome();

        // Call function to prompt for the user's name and store the return value
        string userName = PromptUserName();

        // Call function to prompt for the user's favorite number and store the return value
        int userNumber = PromptUserNumber();

        // Call function to square the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Call function to display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt the user for their name and return it as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt the user for their favorite number and return it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to calculate and return the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result: user's name and the squared number
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
