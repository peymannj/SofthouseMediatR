using MassTransit;
using MediatR;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Notifications;

namespace SofthouseWorker.Consumers;

public class CarCreatedConsumer : IConsumer<CarCreatedMessage>
{
    private readonly IMediator _mediator;

    public CarCreatedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<CarCreatedMessage> context)
    {
        await _mediator.Publish(new CarCreatedNotification(context.Message));
    }
}
