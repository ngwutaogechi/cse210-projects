using System;
using System.Collections.Generic;
using System.Linq;

class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public ScriptureReference(string book, int chapter, int startVerse)
    {
        InitializeReference(book, chapter, startVerse, startVerse);
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        InitializeReference(book, chapter, startVerse, endVerse);
    }

    private void InitializeReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

class Scripture
{
    private List<Word> words;
    private readonly ScriptureReference reference;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        InitializeWords(text);
    }

    private void InitializeWords(string text)
    {
        string[] allWords = text.Split(' ');
        words = allWords.Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference}\n");
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "_____ " : $"{word.Text} ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            int randomIndex = new Random().Next(visibleWords.Count);
            visibleWords[randomIndex].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        ScriptureReference reference = new ScriptureReference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, scriptureText);

        do
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWord();
        } while (!scripture.AllWordsHidden());
    }
}

