using MediatR;
using SofthouseWorker.Notifications;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.NotificationHandlers;

public class CarDeletedEmailHandler : INotificationHandler<CarDeletedNotification>
{
	private readonly IEmailService _mailService;

	public CarDeletedEmailHandler(IEmailService mailService)
	{
		_mailService = mailService;
	}

	public async Task Handle(CarDeletedNotification notification, CancellationToken cancellationToken)
	{
		var messageBody = $"Car '{notification.Message.Name}' with color '{notification.Message.Color}' deleted.";
		await _mailService.SendAsync(string.Empty, "worker@email.io", "Car Deleted", messageBody);
	}
}
