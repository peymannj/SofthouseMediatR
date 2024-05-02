using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SofthouseWorker.Data;
using SofthouseWorker.Extensions;
using SofthouseWorker.Services;
using SofthouseWorker.Services.Interfaces;
using SofthouseWorker.Settings;

var builder = Host.CreateApplicationBuilder();

// Map settings
var rabbitMqSettings = new RabbitMqSettings();
builder.Configuration.GetSection(nameof(RabbitMqSettings)).Bind(rabbitMqSettings);
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection(nameof(SmtpSettings)));

// Dependency injections
builder.Services.AddScoped<IEMailService, EMailService>();

// Add MassTransit service and configuration for RabbitMQ
builder.Services.AddMassTransitWithConfiguration(rabbitMqSettings);

// Configure entity framework
builder.Services.AddDbContext<ApplicationDataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), options =>
    {
        options.EnableRetryOnFailure(5);
    });
});

var app = builder.Build();

app.Run();
