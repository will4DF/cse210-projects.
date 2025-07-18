public class OutdoorEvent : Event
{
    private string weather;

    public OutdoorEvent(string title, string description, string date, string time, string address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $"\nWeather forecast: {weather}";
    }
}
