using MassTransit;
using MediatR;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Notifications;

namespace SofthouseWorker.Consumers;

public class CarDeletedConsumer : IConsumer<CarDeletedMessage>
{
    private readonly IMediator _mediator;

    public CarDeletedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<CarDeletedMessage> context)
    {
        await _mediator.Publish(new CarDeletedNotification(context.Message));
    }
}
