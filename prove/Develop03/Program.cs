using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        var scripture = GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            var input = Console.ReadLine();
            if (input == "quit")
            {
                break;
            }

            if (!scripture.IsCompletelyHidden())
            {
                scripture.HideRandomWords(1);
            }
            else
            {
                Console.WriteLine("All words are hidden! Press 'enter' to reset.");
                Console.ReadLine();
                scripture = GetRandomScripture();
            }
        }
    }

    static Scripture GetRandomScripture()
    {
        string[] lines = File.ReadAllLines("scriptures.csv");
        Random random = new Random();
        int index = random.Next(lines.Length);
    
        string pattern = @",(?=(?:[^""]*""[^""]*"")*[^""]*$)";
        string[] parts = Regex.Split(lines[index], pattern);
    
        string referencePart = parts[0].Trim();
        var reference = ParseReference(referencePart);
        var passage = parts[1].Trim();
    
        return new Scripture(reference, passage);
    }

    static Reference ParseReference(string referencePart)
    {
        var referenceComponents = referencePart.Split(' ');
        var book = referenceComponents[0];
        var chapterAndVerses = referenceComponents[1].Split(':');
        var chapter = int.Parse(chapterAndVerses[0]);

        var verseRange = chapterAndVerses[1].Split('-');
        int startVerse = int.Parse(verseRange[0]);
        int endVerse;

        if (verseRange.Length > 1)
        {
            endVerse = int.Parse(verseRange[1]);
        }
        else
        {
            endVerse = startVerse;
        }

        return new Reference(book, chapter, startVerse, endVerse);
    }
}