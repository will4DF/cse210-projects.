using System.IO.Compression;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");

        int sleepTime = 250;
        int time = 9; // Sleep time in milliseconds

        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(time);

        string animationString2 = "-+\\|/";
        int index = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(animationString2[index++ % animationString2.Length]);
            Thread.Sleep(sleepTime);
            Console.Write("\b");
        }

        int count = time;

        while (DateTime.Now < endTime)
        {
            Console.Write(count--);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        
        string animationString = "(^_^)(-_-)";


        while (DateTime.Now < endTime)
        {
            Console.Write(animationString[0..5]);
            Thread.Sleep(sleepTime);
            Console.Write("\b\b\b\b\b");
            Console.Write(animationString[5..]);
            Thread.Sleep(sleepTime);
            Console.Write("\b\b\b\b\b");
            //Console.Write("\b");
            //Console.Write("-");
            //Thread.Sleep(sleepTime);
            //Console.Write("\b");
        }
    }
}