public class Event
{
    protected string title;
    protected string description;
    protected string date;
    protected string time;
    protected string address;

    public Event(string title, string description, string date, string time, string address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetDetails()
    {
        return $"{title} - {description}\nDate: {date} Time: {time}\nLocation: {address}";
    }

    public virtual string GetShortDescription()
    {
        return $"Event: {title} on {date}";
    }
}
