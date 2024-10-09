public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Get the display text (hidden words appear as underscores)
    public string GetDisplayText()
    {
        return _isHidden ? "____" : _text;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }
}
