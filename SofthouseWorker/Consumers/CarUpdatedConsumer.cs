using MassTransit;
using Microsoft.Extensions.Logging;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.Consumers;

public class CarUpdatedConsumer : IConsumer<CarUpdatedMessage>
{
    private readonly IEMailService _mailService;
    private readonly ILogger<CarCreatedConsumer> _logger;

    public CarUpdatedConsumer(IEMailService mailService, ILogger<CarCreatedConsumer> logger)
    {
        _mailService = mailService;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<CarUpdatedMessage> context)
    {
        _logger.LogInformation("Car updated : {Car}", context.Message);

        var messageBody = $"Car '{context.Message.Name}' with color '{context.Message.Color}' updated.";

        await _mailService
            .SendAsync("sender@email.io", "receiver@email.io", "Car Updated", messageBody);
    }
}
