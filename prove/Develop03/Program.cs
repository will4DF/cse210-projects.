using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Build path to scriptures.txt in same folder as the executable
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scriptures.txt");
        List<Scripture> scriptures = ScriptureLibrary.LoadFromFile(filePath);

        // Check if scriptures were loaded successfully
        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures loaded. Please check that 'scriptures.txt' exists and is formatted correctly.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to finish.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        Console.Clear();
        Console.WriteLine("Memorization complete! All words are hidden.");
    }
}

/*
 * This program randomly selects a scripture from a text file and allows the user to hide words
 * until all words are hidden, simulating a memorization exercise.
 * 
 * The scriptures are loaded from 'scriptures.txt' in the same directory as the executable.
 * Each scripture is displayed with its reference, and the user can hide random words by pressing Enter.
 * The program continues until all words are hidden or the user types 'quit'.
 *
 * EXCEEDING REQUIREMENTS:
 * - Loads multiple scriptures from a text file and randomly selects one each time.
 * - See 'scriptures.txt' for sample scriptures.
 */
