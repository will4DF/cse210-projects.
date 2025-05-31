// See https://aka.ms/new-console-template for more information

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is a test of the WordCounter class.");

        WordCounter wordCounter = new WordCounter("Hello World! This is a test .");
        wordCounter.DisplayWords();

        int count = wordCounter.CountSingleWords("test");

        Console.WriteLine($"The word 'test' appears {count} times.");
    }
    
}