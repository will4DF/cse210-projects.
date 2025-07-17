using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
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
                    writer.WriteLine(totalScore);
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
