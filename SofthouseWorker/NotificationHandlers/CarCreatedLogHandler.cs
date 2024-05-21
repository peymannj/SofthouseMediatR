using MediatR;
using Microsoft.Extensions.Logging;
using SofthouseWorker.Notifications;

namespace SofthouseWorker.NotificationHandlers;

public class CarCreatedLogHandler : INotificationHandler<CarCreatedNotification>
{
	private readonly ILogger<CarCreatedLogHandler> _logger;

	public CarCreatedLogHandler(ILogger<CarCreatedLogHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(CarCreatedNotification notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Car created : {Car}", notification.Message);

		return Task.CompletedTask;
	}
}
