using MassTransit;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Services;

public class MessagingService : IMessagingService
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<MessagingService> _logger;

    public MessagingService(IPublishEndpoint publishEndpoint, ILogger<MessagingService> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    public async Task PublishAsync<T>(T message, string routKey) where T : class
    {
        // You can use context to get more information about the message
        // For example MessageId, and create some logics based on the info

        var messageId = Guid.Empty;

        await _publishEndpoint.Publish(message, context =>
        { 
            messageId = context.MessageId ?? Guid.Empty;
            context.SetRoutingKey(routKey);
        });

        _logger.LogInformation("Message with Id: {MessageId} published", messageId);
    }
}
