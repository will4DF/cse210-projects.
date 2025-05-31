using System.IO;

public static class ScriptureLibrary
{
    public static List<Scripture> LoadFromFile(string filename)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return scriptures;
        }

        foreach (var line in File.ReadAllLines(filename))
        {
            // Format: Book|Chapter|Verse(-EndVerse optional)|Text
            // Example: John|3|16|For God so loved the world...
            var parts = line.Split('|');
            if (parts.Length < 4) continue;

            string book = parts[0];
            int chapter = int.Parse(parts[1]);

            if (parts[2].Contains('-'))
            {
                var verses = parts[2].Split('-');
                var reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
                scriptures.Add(new Scripture(reference, parts[3]));
            }
            else
            {
                var reference = new Reference(book, chapter, int.Parse(parts[2]));
                scriptures.Add(new Scripture(reference, parts[3]));
            }
        }

        return scriptures;
    }
}
