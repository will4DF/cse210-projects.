using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude Journal Activity",
        "This activity will help you focus on the positive by writing about something you're grateful for.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Think of something you are grateful for.");
        ShowSpinner(5);
        Console.WriteLine("Now, describe it in detail. You have the duration to write.");

        List<string> lines = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) lines.Add(input);
        }

        Console.WriteLine($"\nYou wrote {lines.Count} lines about gratitude.");
        DisplayEndingMessage();
        LogToFile($"{_name} for {_duration} seconds with {lines.Count} lines.");
    }
}
