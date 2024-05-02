using MassTransit;
using Microsoft.Extensions.Logging;
using SofthouseCommon.MessageContracts;
using SofthouseWorker.Services.Interfaces;

namespace SofthouseWorker.Consumers;

public class CarDeletedConsumer : IConsumer<CarDeletedMessage>
{
    private readonly IEMailService _mailService;
    private readonly ILogger<CarDeletedConsumer> _logger;

    public CarDeletedConsumer(IEMailService mailService, ILogger<CarDeletedConsumer> logger)
    {
        _logger = logger;
        _mailService = mailService;
    }

    public async Task Consume(ConsumeContext<CarDeletedMessage> context)
    {
        _logger.LogInformation("Car deleted : {Car}", context.Message);

        var messageBody = $"Car '{context.Message.Name}' with color '{context.Message.Color}' deleted.";

        await _mailService
            .SendAsync("sender@email.io", "receiver@email.io", "Car Deleted", messageBody);
    }
}
