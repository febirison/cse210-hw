public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int? verseEnd; // Nullable int for handling verse ranges

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        if (verseEnd != null)
            return $"{book} {chapter}:{verseStart}-{verseEnd}";
        else
            return $"{book} {chapter}:{verseStart}";
    }
}
