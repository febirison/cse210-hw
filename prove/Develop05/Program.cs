// This program exceeds the core requirements by:
// 1. Adding a Gratitude Journal activity
// 2. Implementing an activity log to track usage
// 3. Ensuring all prompts and questions are used before repeating
// 4. Saving and loading log files (activity log and gratitude journal)
// 5. Enhancing the user interface with clear menus and improved animations

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    private static Dictionary<string, int> activityLog = new Dictionary<string, int>();
    private static string logFilePath = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        LoadLog();
        DisplayWelcomeMessage();

        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    LogActivity("Breathing");
                    break;
                case "2":
                    new ListingActivity().Run();
                    LogActivity("Listing");
                    break;
                case "3":
                    new ReflectingActivity().Run();
                    LogActivity("Reflecting");
                    break;
                case "4":
                    new GratitudeJournalActivity().Run();
                    LogActivity("Gratitude Journal");
                    break;
                case "5":
                    ViewActivityLog();
                    break;
                case "6":
                    SaveLog();
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != "5" && choice != "6")
            {
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }
    }

    private static void DisplayWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("=== Welcome to the Mindfulness Program ===");
        Console.WriteLine("\nThis application is designed to help you improve your mental well-being through various mindfulness activities.");
        Console.WriteLine("\nWhat to expect:");
        Console.WriteLine("1. Breathing Activity: Guide you through deep breathing exercises.");
        Console.WriteLine("2. Listing Activity: Help you reflect on the positive aspects of your life.");
        Console.WriteLine("3. Reflecting Activity: Encourage you to ponder on past experiences and personal growth.");
        Console.WriteLine("4. Gratitude Journal: Assist you in cultivating gratitude by recording your thoughts.");
        Console.WriteLine("5. Activity Log: Track your progress and engagement with the program.");
        Console.WriteLine("\nEach activity will provide clear instructions and guide you through the process.");
        Console.WriteLine("Take your time, be honest with yourself, and enjoy the journey to mindfulness.");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness Program ===");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Listing Activity");
        Console.WriteLine("3. Reflecting Activity");
        Console.WriteLine("4. Gratitude Journal");
        Console.WriteLine("5. View Activity Log");
        Console.WriteLine("6. Quit");
        Console.Write("\nChoose an activity (1-6): ");
    }

    private static void LogActivity(string activityName)
    {
        if (activityLog.ContainsKey(activityName))
        {
            activityLog[activityName]++;
        }
        else
        {
            activityLog[activityName] = 1;
        }
        SaveLog();
    }

    private static void ViewActivityLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log ===");
        if (activityLog.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            foreach (var activity in activityLog)
            {
                Console.WriteLine($"{activity.Key}: {activity.Value} time(s)");
            }
        }
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey();
    }

    private static void SaveLog()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath))
            {
                foreach (var activity in activityLog)
                {
                    writer.WriteLine($"{activity.Key},{activity.Value}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving activity log: {ex.Message}");
        }
    }

    private static void LoadLog()
    {
        if (File.Exists(logFilePath))
        {
            try
            {
                string[] lines = File.ReadAllLines(logFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        activityLog[parts[0]] = int.Parse(parts[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading activity log: {ex.Message}");
            }
        }
    }
}