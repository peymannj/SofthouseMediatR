using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using SofthouseCommon.Constants;
using SofthouseWorker.Consumers;
using SofthouseWorker.Data;
using SofthouseWorker.Settings;

namespace SofthouseWorker.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransitWithConfiguration(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
    {
        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<ApplicationDataContext>(configurator =>
            {
                configurator.DuplicateDetectionWindow = TimeSpan.FromSeconds(30);
                configurator.UseSqlServer();
            });
    
            x.SetKebabCaseEndpointNameFormatter();

            // Scan all the consumers in the project and add them.
            x.AddConsumers(Assembly.GetExecutingAssembly(), typeof(Program).Assembly);

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(rabbitMqSettings.HostName , "/", _ => {});
                configurator.ConfigureEndpoints(context);

                configurator.UseMessageRetry(retry => retry.Interval(5, TimeSpan.FromSeconds(5)));

                configurator.ReceiveEndpoint(MessageBrokerSettings.QueueName, endpointConfigurator =>
                {
                    // turns off default Fanout settings
                    endpointConfigurator.ConfigureConsumeTopology = false;

                    // a replicated queue to provide high availability and data safety. available in RMQ 3.8+
                    endpointConfigurator.SetQuorumQueue();

                    //PrefetchCount parameter in a ReceiveEndpoint configuration is used to control how many
                    //messages are fetched and held in memory by a consumer (consumer prefetch). This parameter
                    //can significantly affect the performance and behavior of consumers. The count should be 
                    //chosen wisely otherwise it affect the performance in a opposite way.
                    endpointConfigurator.PrefetchCount = MessageBrokerSettings.PrefetchCount;

                    endpointConfigurator.ConfigureConsumer<CarCreatedConsumer>(context);
                    endpointConfigurator.ConfigureConsumer<CarUpdatedConsumer>(context);
                    endpointConfigurator.ConfigureConsumer<CarDeletedConsumer>(context);

                    endpointConfigurator.Bind(MessageBrokerSettings.ExchangeName, bindingConfigurator =>
                    {
                        bindingConfigurator.RoutingKey = MessageBrokerSettings.CarTopicRout;
                        bindingConfigurator.ExchangeType = ExchangeType.Topic;
                    });
                });
            });
        });

        return services;
    }
}
