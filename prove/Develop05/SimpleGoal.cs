using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points) {}

        public override int RecordEvent()
        {
            if (!isComplete)
            {
                isComplete = true;
                Console.WriteLine($"Goal '{name}' completed! You earned {points} points.");
                return points;
            }
            else
            {
                Console.WriteLine($"Goal '{name}' already completed.");
                return 0;
            }
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{name},{description},{points},{isComplete}";
        }

        public void SetComplete(bool complete)
        {
            isComplete = complete;
        }
    }
}
