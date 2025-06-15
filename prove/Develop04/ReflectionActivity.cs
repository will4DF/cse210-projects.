using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself through this experience?",
        "How did you get started?",
        "What made this time different?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _unusedQuestions = new List<string>();
    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];

    private string GetNextQuestion()
    {
        if (_unusedQuestions.Count == 0)
            _unusedQuestions = new List<string>(_questions);
        int index = _random.Next(_unusedQuestions.Count);
        string q = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);
        return q;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine($"> {GetRandomPrompt()}\n");
        ShowSpinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine($"> {GetNextQuestion()}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
        LogToFile($"{_name} for {_duration} seconds.");
    }
}
