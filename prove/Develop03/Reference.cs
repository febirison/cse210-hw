public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd; // Nullable int for handling verse ranges

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (_verseEnd != null)
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{_book} {_chapter}:{_verseStart}";
    }
}
