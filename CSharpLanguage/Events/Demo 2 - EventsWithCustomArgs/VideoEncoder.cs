namespace Events.EventsWithCustomArgs;

public sealed class VideoEncoder
{
    // 1 - Define a delegate
    public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
    
    // 2 - Define event based on the delegate
    public event VideoEncodedEventHandler? VideoEncoded;
    
    public void Encode(Video video)
    {
        Console.WriteLine("Enconding Video... ");
        Thread.Sleep(3000);
        
        OnVideoEncoded(video);
    }
    
    // 3 - Raise the event
    private void OnVideoEncoded(Video video)
    {
        VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video });
    }
}