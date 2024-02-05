namespace Events.Demo_1___BasicEvents;

public class MailService
{
    public void OnVideoEncoded(object source, EventArgs e)
    {
        Console.WriteLine("MailService: Sending an email... ");
    }
}