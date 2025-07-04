using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Base class
    public abstract class Goal
    {
        protected string name;
        protected string description;
        protected int points;
        protected bool isComplete;

        public Goal(string name, string description, int points)
        {
            this.name = name;
            this.description = description;
            this.points = points;
            isComplete = false;
        }

        public abstract int RecordEvent();

        public virtual string GetStatus()
        {
            return isComplete ? "[X]" : "[ ]";
        }

        public override string ToString()
        {
            return $"{GetStatus()} {name} ({description})";
        }

        public abstract string GetStringRepresentation();

        // Factory method for loading goals from string
        public static Goal CreateGoalFromString(string line)
        {
            // Format: GoalType:details...
            string[] parts = line.Split(':');
            if (parts.Length != 2)
                return null;

            string type = parts[0];
            string data = parts[1];
            string[] fields = data.Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    // name,description,points,isComplete
                    if (fields.Length < 4) return null;
                    var sg = new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]));
                    sg.SetComplete(bool.Parse(fields[3]));
                    return sg;

                case "EternalGoal":
                    // name,description,points
                    if (fields.Length < 3) return null;
                    return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));

                case "ChecklistGoal":
                    // name,description,points,targetCount,bonusPoints,currentCount,isComplete
                    if (fields.Length < 7) return null;
                    var cg = new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]));
                    cg.SetCurrentCount(int.Parse(fields[5]));
                    cg.SetComplete(bool.Parse(fields[6]));
                    return cg;

                default:
                    return null;
            }
        }
    }

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

        // For loading completeness
        public void SetComplete(bool complete)
        {
            isComplete = complete;
        }
    }

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

        // For loading
        public void SetCurrentCount(int count)
        {
            currentCount = count;
        }

        public void SetComplete(bool complete)
        {
            isComplete = complete;
        }
    }

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;
        const string filename = "goals.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");

            LoadGoals();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record event for a goal");
                Console.WriteLine("4. Show total score");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Load goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        ShowScore();
                        break;
                    case "5":
                        SaveGoals();
                        break;
                    case "6":
                        LoadGoals();
                        break;
                    case "7":
                        quit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. Simple Goal (complete once)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (multiple completions with bonus)");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            int points = PromptForInt("Enter points earned per completion: ");

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, description, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, description, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    int targetCount = PromptForInt("Enter target completion count: ");
                    int bonusPoints = PromptForInt("Enter bonus points upon completion: ");
                    goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void ListGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            Console.WriteLine("Your goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
        }

        static void RecordEvent()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                return;
            }

            ListGoals();
            int choice = PromptForInt("Select a goal to record event for (number): ");

            if (choice < 1 || choice > goals.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            int pointsEarned = goals[choice - 1].RecordEvent();
            totalScore += pointsEarned;
            Console.WriteLine($"Total score: {totalScore}");
        }

        static void ShowScore()
        {
            Console.WriteLine($"Your total score is: {totalScore}");
        }

        static void SaveGoals()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(totalScore); // Save score on first line
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        static void LoadGoals()
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filename);
                if (lines.Length == 0)
                {
                    Console.WriteLine("Saved goals file is empty.");
                    return;
                }

                goals.Clear();
                totalScore = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    Goal g = Goal.CreateGoalFromString(lines[i]);
                    if (g != null)
                    {
                        goals.Add(g);
                    }
                }
                Console.WriteLine($"Loaded {goals.Count} goals. Total score: {totalScore}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }

        static int PromptForInt(string message)
        {
            int result;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input. Try again: ");
            }
            return result;
        }
    }
}
