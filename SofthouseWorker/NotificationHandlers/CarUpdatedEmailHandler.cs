using MediatR;
using SofthouseWorker.Notifications;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.NotificationHandlers;

public class CarUpdatedEmailHandler : INotificationHandler<CarUpdatedNotification>
{
	private readonly IEmailService _mailService;

	public CarUpdatedEmailHandler(IEmailService mailService)
	{
		_mailService = mailService;
	}

	public async Task Handle(CarUpdatedNotification notification, CancellationToken cancellationToken)
	{
		var messageBody = $"Car '{notification.Message.Name}' with color '{notification.Message.Color}' updated.";
		await _mailService.SendAsync(string.Empty, "worker@email.io", "Car updated", messageBody);
	}
}
