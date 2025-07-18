using System;

class Program
{
    static void Main()
    {
        Lecture lecture = new Lecture("Tech Talk", "AI in 2025", "2025-08-01", "7:00 PM", "123 Hall St", "Dr. Smart", 100);
        Reception reception = new Reception("Wedding Reception", "Celebrate with us!", "2025-09-15", "5:00 PM", "456 Garden Ave", "rsvp@event.com");
        OutdoorEvent outdoor = new OutdoorEvent("Picnic", "Family picnic in the park", "2025-07-25", "12:00 PM", "789 Park Rd", "Sunny");

        Console.WriteLine("Lecture Details:\n" + lecture.GetDetails());
        Console.WriteLine("\nReception Details:\n" + reception.GetDetails());
        Console.WriteLine("\nOutdoor Event Details:\n" + outdoor.GetDetails());
    }
}
