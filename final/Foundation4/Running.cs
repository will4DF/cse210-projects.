public class Running : Activity
{
    private double distance;

    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override string GetSummary()
    {
        return $"{date} Running ({minutes} min): {distance} miles";
    }
}
