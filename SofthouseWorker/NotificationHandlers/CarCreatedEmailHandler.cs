using MediatR;
using SofthouseWorker.Notifications;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.NotificationHandlers;

public class CarCreatedEmailHandler : INotificationHandler<CarCreatedNotification>
{
	private readonly IEmailService _mailService;

	public CarCreatedEmailHandler(IEmailService mailService)
	{
		_mailService = mailService;
	}

	public async Task Handle(CarCreatedNotification notification, CancellationToken cancellationToken)
	{
		var messageBody = $"Car '{notification.Message.Name}' with color '{notification.Message.Color}' created.";
		await _mailService.SendAsync(string.Empty, "worker@email.io", "Car Created", messageBody);
	}
}
