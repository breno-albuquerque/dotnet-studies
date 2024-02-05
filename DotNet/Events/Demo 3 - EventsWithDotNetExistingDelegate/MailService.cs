namespace Events.Demo_3___EventsWithDotNetExistingDelegate;

public class MailService
{
    public void OnVideoEncoded(object? source, VideoEventArgs e)
    {
        Console.WriteLine($"MailService: Sending an email. Video: {e.Video.Title}");
    }
}