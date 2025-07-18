using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("2025-07-10", 30, 3.5),
            new Cycling("2025-07-11", 45, 15.2),
            new Swimming("2025-07-12", 40, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
