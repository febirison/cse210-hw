// Code By Anderson Okai

using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        // Step 2: Determine the letter grade
        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 3: Determine the sign (+ or -)
        string sign = "";
        int lastDigit = percent % 10;

        if (letter != "A" && letter != "F") // No A+ or F+
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Step 4: Display the final grade with letter and sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Step 5: Determine if the user passed
        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
