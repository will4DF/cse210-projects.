public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, string address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $"\nRSVP: {rsvpEmail}";
    }
}
