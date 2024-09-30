//Code by Anderson Okai
// Added a new feature where the user can rate their day on a scale of 1 to 10.
// This rating is stored as part of the journal entry and displayed along with the prompt, response, and date.
// The user is prompted to enter a rating each time they make a new journal entry.


class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see the hand of the Lord in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could do one thing over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Random rand = new Random();
                    string randomPrompt = prompts[rand.Next(prompts.Count)];
                    Console.WriteLine(randomPrompt);
                    string response = Console.ReadLine();

                    // Ask the user for a rating of their day
                    Console.WriteLine("On a scale of 1 to 10, how would you rate your day?");
                    int rating = int.Parse(Console.ReadLine());

                    myJournal.AddEntry(new Entry(randomPrompt, response, rating));
                    break;

                case "2":
                    myJournal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    myJournal.SaveToFile(saveFileName);
                    break;

                case "4":
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    myJournal.LoadFromFile(loadFileName);
                    break;

                case "5":
                    return;
            }
        }
    }
}
