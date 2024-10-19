using System;
using System.Collections.Generic;
using System.IO;

public class GratitudeJournalActivity : Activity
{
    private List<string> _entries;
    private string _journalFilePath = "gratitude_journal.txt";

    public GratitudeJournalActivity()
    {
        _name = "Gratitude Journal";
        _description = "This activity will help you focus on the positive aspects of your life by writing down things you're grateful for.";
        _entries = new List<string>();
        LoadJournal();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Take a moment to think about something you're grateful for today.");
        Console.WriteLine("When you're ready, write your gratitude entry:");
        string entry = Console.ReadLine();
        _entries.Add($"{DateTime.Now}: {entry}");

        SaveJournal();

        Console.WriteLine("\nHere are your recent gratitude entries:");
        DisplayRecentEntries();

        DisplayEndingMessage();
    }

    private void LoadJournal()
    {
        if (File.Exists(_journalFilePath))
        {
            _entries = new List<string>(File.ReadAllLines(_journalFilePath));
        }
    }

    private void SaveJournal()
    {
        File.WriteAllLines(_journalFilePath, _entries);
    }

    private void DisplayRecentEntries()
    {
        int entriesToShow = Math.Min(5, _entries.Count);
        for (int i = _entries.Count - entriesToShow; i < _entries.Count; i++)
        {
            Console.WriteLine(_entries[i]);
        }
    }
}