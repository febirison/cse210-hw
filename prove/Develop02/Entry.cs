public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public int Rating { get; set; } // Added a rating field

    // Updated constructor to take the rating as well
    public Entry(string prompt, string response, int rating)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToShortDateString();
        Rating = rating;
    }

    // Display method updated to include the rating
    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nRating: {Rating}/10\n");
    }
}
