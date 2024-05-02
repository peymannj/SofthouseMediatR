namespace SofthouseMediatR.Services.Interfaces;

public interface IMessagingService
{
    Task PublishAsync<T>(T message, string routKey) where T : class;
}
