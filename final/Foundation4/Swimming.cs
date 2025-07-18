public class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override string GetSummary()
    {
        return $"{date} Swimming ({minutes} min): {laps} laps";
    }
}
