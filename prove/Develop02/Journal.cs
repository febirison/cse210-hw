public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                // Save the rating as well
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}|{entry.Rating}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            _entries.Add(new Entry(parts[1], parts[2], int.Parse(parts[3])) { Date = parts[0] });
        }
    }
}
