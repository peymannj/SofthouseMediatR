using MediatR;
using SofthouseCommon.MessageContracts;

namespace SofthouseWorker.Notifications;

public class CarCreatedNotification : INotification
{
	public CarCreatedMessage Message{ get; set; }
	
	public CarCreatedNotification(CarCreatedMessage message)
	{
		Message = message;
	}
}
