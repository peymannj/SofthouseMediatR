using MediatR;
using SofthouseCommon.MessageContracts;

namespace SofthouseWorker.Notifications;

public class CarDeletedNotification : INotification
{
	public CarDeletedMessage Message{ get; set; }
	
	public CarDeletedNotification(CarDeletedMessage message)
	{
		Message = message;
	}
}
