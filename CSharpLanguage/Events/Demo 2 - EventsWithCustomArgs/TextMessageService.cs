namespace Events.EventsWithCustomArgs;

public class TextMessageService
{
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        Console.WriteLine($"TextMessageService: Sending a text message. Video: {e.Video.Title}");
    }
}