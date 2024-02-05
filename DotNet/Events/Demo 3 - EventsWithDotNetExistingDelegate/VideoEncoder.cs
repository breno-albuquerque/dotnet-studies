namespace Events.Demo_3___EventsWithDotNetExistingDelegate;

public sealed class VideoEncoder
{
    // 1 - Podemos utilizar o delegate já existente no .NET.
    // 1.2 - Sem argumentos: EventHandler
    // 1.3 - Com argumentos: EventHandler<ArgsType>
    
    public event EventHandler<VideoEventArgs>? VideoEncoded;
    
    public void Encode(Video video)
    {
        Console.WriteLine("Enconding Video... ");
        Thread.Sleep(3000);
        
        OnVideoEncoded(video);
    }
    
    // 2 - Raise the event
    private void OnVideoEncoded(Video video)
    {
        VideoEncoded?.Invoke(this, new VideoEventArgs() { Video = video });
    }
}