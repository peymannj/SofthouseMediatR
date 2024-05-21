using MassTransit;
using RabbitMQ.Client;
using SofthouseCommon.MessageContracts;
using SofthouseMediatR.DataContext;
using SofthouseMediatR.Settings;

namespace SofthouseMediatR.Extensions;

public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransitWithConfiguration(this IServiceCollection services, RabbitMqSettings rabbitMqSettings)
    {
        services.AddMassTransit(x =>
        {
            x.AddEntityFrameworkOutbox<ApplicationDataContext>(configurator =>
            {
                configurator.QueryDelay = TimeSpan.FromSeconds(1);
                configurator.UseSqlServer().UseBusOutbox();
            });

            x.UsingRabbitMq((_, configurator) =>
            {
                configurator.Host(rabbitMqSettings.HostName,"/",  hostConfigurator =>
                {
                    hostConfigurator.Username(rabbitMqSettings.Username);
                    hostConfigurator.Password(rabbitMqSettings.Password);
                });

                configurator.UseMessageRetry(retry => retry.Interval(5, TimeSpan.FromSeconds(5)));

                configurator.Message<CarCreatedMessage>(topologyConfigurator  =>
                    topologyConfigurator.SetEntityName("softhouse"));
                configurator.Publish<CarCreatedMessage>(topologyConfigurator =>
                    topologyConfigurator.ExchangeType = ExchangeType.Topic);

                configurator.Message<CarUpdatedMessage>(topologyConfigurator  =>
                    topologyConfigurator.SetEntityName("softhouse"));
                configurator.Publish<CarUpdatedMessage>(topologyConfigurator =>
                    topologyConfigurator.ExchangeType = ExchangeType.Topic);
        
                configurator.Message<CarDeletedMessage>(topologyConfigurator  =>
                    topologyConfigurator.SetEntityName("softhouse"));
                configurator.Publish<CarDeletedMessage>(topologyConfigurator =>
                    topologyConfigurator.ExchangeType = ExchangeType.Topic);
            });
        });

        return services;
    }
}
