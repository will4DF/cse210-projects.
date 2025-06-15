using System;
using System.Collections.Generic;

// EXCEEDING REQUIREMENTS:
// - Added Gratitude Journal activity
// - Avoided repeated prompts until all used
// - Tracked session activity counts
// - Logged all activity usage to activity_log.txt

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityCounts = new Dictionary<string, int>()
        {
            { "Breathing", 0 }, { "Reflection", 0 }, { "Listing", 0 }, { "Gratitude", 0 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Journal Activity");
            Console.WriteLine("5. Show Session Summary");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice (1-6): ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": activity = new GratitudeActivity(); break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Session Summary:");
                    foreach (var kv in activityCounts)
                        Console.WriteLine($"{kv.Key} Activity: {kv.Value} time(s)");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    continue;
                case "6": return;
                default: continue;
            }

            activity.Run();
            string key = activity.GetType().Name.Replace("Activity", "");
            if (activityCounts.ContainsKey(key))
                activityCounts[key]++;
        }
    }
}
