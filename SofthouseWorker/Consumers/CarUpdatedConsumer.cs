using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Notifications;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.Consumers;

public class CarUpdatedConsumer : IConsumer<CarUpdatedMessage>
{
    private readonly IMediator _mediator;

    public CarUpdatedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<CarUpdatedMessage> context)
    {
        await _mediator.Publish(new CarUpdatedNotification(context.Message));
    }
}
