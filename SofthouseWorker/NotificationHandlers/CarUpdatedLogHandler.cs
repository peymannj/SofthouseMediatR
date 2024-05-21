using MediatR;
using Microsoft.Extensions.Logging;
using SofthouseWorker.Notifications;

namespace SofthouseWorker.NotificationHandlers;

public class CarUpdatedLogHandler : INotificationHandler<CarUpdatedNotification>
{
	private readonly ILogger<CarUpdatedLogHandler> _logger;

	public CarUpdatedLogHandler(ILogger<CarUpdatedLogHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(CarUpdatedNotification notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Car updated : {Car}", notification.Message);

		return Task.CompletedTask;
	}
}
