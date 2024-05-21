using MediatR;
using Microsoft.Extensions.Logging;
using SofthouseWorker.Notifications;

namespace SofthouseWorker.NotificationHandlers;

public class CarDeletedLogHandler : INotificationHandler<CarDeletedNotification>
{
	private readonly ILogger<CarDeletedLogHandler> _logger;

	public CarDeletedLogHandler(ILogger<CarDeletedLogHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(CarDeletedNotification notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation("Car deleted : {Car}", notification.Message);

		return Task.CompletedTask;
	}
}
