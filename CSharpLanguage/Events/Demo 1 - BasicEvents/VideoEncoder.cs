namespace Events.BasicEvents;

public sealed class VideoEncoder
{
    // 1 - Define a delegate
    public delegate void VideoEncodedEventHandler(object source, EventArgs args);
    
    // 2 - Define event based on the delegate
    public event VideoEncodedEventHandler? VideoEncoded;
    
    public void Encode(Video video)
    {
        Console.WriteLine("Enconding Video... ");
        Thread.Sleep(3000);
        
        OnVideoEncoded();
    }
    
    // 3 - Raise the event
    private void OnVideoEncoded()
    {
        VideoEncoded?.Invoke(this, EventArgs.Empty);
    }
}