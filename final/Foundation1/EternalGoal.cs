using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) {}

        public override int RecordEvent()
        {
            Console.WriteLine($"Goal '{name}' recorded! You earned {points} points.");
            return points;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{name},{description},{points}";
        }

        public override string GetStatus()
        {
            return "[∞]";
        }
    }
}
