using MediatR;
using SofthouseCommon.MessageContracts;

namespace SofthouseWorker.Notifications;

public class CarUpdatedNotification : INotification
{
	public CarUpdatedMessage Message{ get; set; }
	
	public CarUpdatedNotification(CarUpdatedMessage message)
	{
		Message = message;
	}
}
