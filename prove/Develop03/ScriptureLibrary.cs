public class ScriptureLibrary
{
    private List<Scripture> scriptures;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
        // Add 10 scriptures to the library
        scriptures.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."));
        scriptures.Add(new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."));
        scriptures.Add(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."));
        scriptures.Add(new Scripture(new Reference("Isaiah", 40, 31), "But they that wait upon the Lord shall renew their strength; they shall mount up with wings as eagles; they shall run, and not be weary; and they shall walk, and not faint."));
        scriptures.Add(new Scripture(new Reference("Jeremiah", 29, 11), "For I know the thoughts that I think toward you, saith the Lord, thoughts of peace, and not of evil, to give you an expected end."));
        scriptures.Add(new Scripture(new Reference("Matthew", 6, 33), "But seek ye first the kingdom of God, and his righteousness; and all these things shall be added unto you."));
        scriptures.Add(new Scripture(new Reference("Joshua", 1, 9), "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."));
        scriptures.Add(new Scripture(new Reference("1 Peter", 5, 7), "Casting all your care upon him; for he careth for you."));
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        return scriptures[random.Next(scriptures.Count)];
    }
}
