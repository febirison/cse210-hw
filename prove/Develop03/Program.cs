// CREATIVE FEATURE: Added difficulty level selection (easy, medium, hard) to enhance user experience.
// This feature allows the user to control how many words are hidden in each round based on their selected difficulty.
// Easy hides 1 word at a time, Medium hides 3 words, and Hard hides 5 words.
// This addition makes the program more interactive and personalized, going beyond the core requirements.


using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create the scripture library
        ScriptureLibrary library = new ScriptureLibrary();

        // Select difficulty level (CREATIVE FEATURE)
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Choose difficulty level: Easy (1 word), Medium (3 words), Hard (5 words)");
        Console.WriteLine("Enter 'easy', 'medium', or 'hard': ");
        string difficulty = Console.ReadLine().ToLower();

        int wordsToHide = difficulty switch
        {
            "easy" => 1,
            "medium" => 3,
            "hard" => 5,
            _ => 3 // Default to medium if input is invalid
        };

        // Get a random scripture
        Scripture scripture = library.GetRandomScripture();

        // Start the memorization process
        while (true)
        {
            Console.Clear();
            scripture.Display();

            // Program termination if all words are hidden (MET FUNCTIONALITY REQUIREMENT #7)
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Program finished.");
                break;
            }

            // Allow the user to quit or continue
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye! Thank you for using the Scripture Memorizer.");
                break;
            }

            // Hide words based on the difficulty level selected
            scripture.HideRandomWords(wordsToHide);
        }
    }
}
