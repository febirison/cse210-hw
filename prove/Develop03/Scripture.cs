using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenWords = 0;

        while (hiddenWords < count)
        {
            int index = random.Next(words.Count);
            if (!words[index].IsHidden())
            {
                words[index].Hide();
                hiddenWords++;
            }
        }
    }

    public void Display()
    {
        Console.WriteLine(reference.GetDisplayText());
        foreach (var word in words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public bool AllWordsHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
