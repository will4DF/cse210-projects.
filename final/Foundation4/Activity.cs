public abstract class Activity
{
    protected string date;
    protected int minutes;

    public Activity(string date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public abstract string GetSummary();
}
