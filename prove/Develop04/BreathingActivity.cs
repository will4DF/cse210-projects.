using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by guiding you through breathing in and out slowly.") {}

    public override void Run()
    {
        DisplayStartingMessage();
        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            Console.WriteLine("Breathe out...");
            ShowCountdown(6);
        }
        DisplayEndingMessage();
        LogToFile($"{_name} for {_duration} seconds.");
    }
}
