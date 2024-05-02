using MassTransit;
using Microsoft.Extensions.Logging;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.Consumers;

public class CarCreatedConsumer : IConsumer<CarCreatedMessage>
{
    private readonly IEMailService _mailService;
    private readonly ILogger<CarCreatedConsumer> _logger;

    public CarCreatedConsumer(IEMailService mailService, ILogger<CarCreatedConsumer> logger)
    {
        _mailService = mailService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CarCreatedMessage> context)
    {
        _logger.LogInformation("Car created : {Car}", context.Message);

        var messageBody = $"Car '{context.Message.Name}' with color '{context.Message.Color}' created.";

        await _mailService
            .SendAsync("sender@email.io", "receiver@email.io", "Car Created", messageBody);
    }
}
