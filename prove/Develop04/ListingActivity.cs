using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _unusedPrompts = new List<string>();
    private Random _random = new Random();

    public ListingActivity() : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list them.") {}

    private string GetNextPrompt()
    {
        if (_unusedPrompts.Count == 0)
            _unusedPrompts = new List<string>(_prompts);
        int index = _random.Next(_unusedPrompts.Count);
        string p = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return p;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetNextPrompt();
        Console.WriteLine($"> {prompt}");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) items.Add(input);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
        LogToFile($"{_name} for {_duration} seconds with {items.Count} items.");
    }
}
