using System.Reflection;
using JetBrains.Annotations;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

// Demo
var serviceCollection = new ServiceCollection()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
    .BuildServiceProvider();

var mediator = serviceCollection.GetRequiredService<IMediator>();

await mediator.Send(new PingCommand());

public class PingCommand : IRequest<PongResponse>
{
}

public class PongNotification : INotification
{
    public DateTime Timestamp { get; set; }

    public PongNotification(DateTime timestamp)
    {
        Timestamp = timestamp;
    }
}

public class PongResponse
{
    public DateTime Timestamp { get; set; }

    public PongResponse(DateTime timestamp)
    {
        Timestamp = timestamp;
    }
}


[UsedImplicitly] // JetBrains.Annotations apenas para não marcar a classe por não estar sendo instanciada
public class FirstCommandHandler : IRequestHandler<PingCommand, PongResponse>
{
    private readonly IMediator _mediator;

    public FirstCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<PongResponse> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new PongNotification(DateTime.Now), cancellationToken);
        
        return await Task.FromResult(new PongResponse(DateTime.Now));
    }
}

[UsedImplicitly] 
public class LogNotifications : INotificationHandler<PongNotification>
{
    public Task Handle(PongNotification notification, CancellationToken cancellationToken)
    {
        Task.Run(() => Console.WriteLine($"Pong notification received at {notification.Timestamp}"), cancellationToken).Wait(cancellationToken);
        return Task.CompletedTask;
    }
}