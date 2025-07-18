public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, string address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $"\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}
