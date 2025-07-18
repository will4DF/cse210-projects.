using System;
using System.Collections.Generic;
using System.Linq;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(string name, string text)
    {
        comments.Add(new Comment(name, text));
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($" - {comment.Name}: {comment.Text}");
        }
        Console.WriteLine($"Average Comment Length: {GetAverageCommentLength():F1} characters");
        Console.WriteLine($"Longest Comment: \"{GetLongestComment()}\"");
    }

    private double GetAverageCommentLength()
    {
        if (comments.Count == 0) return 0;
        double totalLength = comments.Sum(c => c.Text.Length);
        return totalLength / comments.Count;
    }

    private string GetLongestComment()
    {
        if (comments.Count == 0) return "";
        return comments.OrderByDescending(c => c.Text.Length).First().Text;
    }
}
