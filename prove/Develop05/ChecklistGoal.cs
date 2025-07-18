using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int targetCount;
        private int currentCount;
        private int bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            this.targetCount = targetCount;
            this.bonusPoints = bonusPoints;
            currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (!isComplete)
            {
                currentCount++;
                if (currentCount >= targetCount)
                {
                    isComplete = true;
                    Console.WriteLine($"Goal '{name}' completed! You earned {points} points + {bonusPoints} bonus points.");
                    return points + bonusPoints;
                }
                else
                {
                    Console.WriteLine($"Progress recorded for '{name}'. You earned {points} points. Completed {currentCount}/{targetCount}.");
                    return points;
                }
            }
            else
            {
                Console.WriteLine($"Goal '{name}' already completed.");
                return 0;
            }
        }

        public override string GetStatus()
        {
            return isComplete ? "[X]" : "[ ]";
        }

        public string GetProgress()
        {
            return $"Completed {currentCount}/{targetCount}";
        }

        public override string ToString()
        {
            return $"{GetStatus()} {name} ({description}) -- {GetProgress()}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{name},{description},{points},{targetCount},{bonusPoints},{currentCount},{isComplete}";
        }

        public void SetCurrentCount(int count)
        {
            currentCount = count;
        }

        public void SetComplete(bool complete)
        {
            isComplete = complete;
        }
    }
}
