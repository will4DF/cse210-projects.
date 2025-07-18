public class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override string GetSummary()
    {
        return $"{date} Cycling ({minutes} min): Speed {speed} mph";
    }
}
