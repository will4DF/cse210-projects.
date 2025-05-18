using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"Entry {i + 1}:\n{entries[i]}");
        }
    }


    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File \"{filename}\" not found. Please save the journal first.");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            entries.Add(Entry.FromFileString(line));
        }
    }
    public void DeleteEntry(int index)
    {
        if (index >= 0 && index < entries.Count)
        {
            entries.RemoveAt(index);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {   
            Console.WriteLine("Invalid entry number.");
        }
    }

}


