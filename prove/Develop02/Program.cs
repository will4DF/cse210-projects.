using System;

/*
 * This program goes beyond the basics by letting users delete journal entries,
 * which makes it easier to manage their journal. It also saves the exact time
 * each entry is written, so you get a more detailed timestamp instead of just the date.
 */
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Delete an entry");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("g");
                    Entry entry = new Entry(date, prompt, response);
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine($"Journal saved to \"{saveFile}\".");  // Confirmation message
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine($"Journal loaded from \"{loadFile}\".");  // Confirmation message
                    break;
                case "5":
                    running = false;
                    break;
                case "6":
                    journal.DisplayEntries();
                    Console.Write("Enter the number of the entry to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int entryNumber))
                    {
                        journal.DeleteEntry(entryNumber - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
