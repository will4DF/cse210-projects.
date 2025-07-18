using System;

class Program
{
    static void Main()
    {
        Video video1 = new Video("How to Code", "John Doe", 300);
        video1.AddComment("Alice", "Great video!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Charlie", "Awesome explanation.");

        video1.Display();
    }
}
