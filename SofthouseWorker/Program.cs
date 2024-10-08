﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SofthouseWorker.Data;
using SofthouseWorker.Extensions;
using SofthouseWorker.Services;
using SofthouseWorker.Services.Interfaces;
using SofthouseWorker.Settings;

var builder = Host.CreateApplicationBuilder();

//Add support to logging with SERILOG
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

// Map settings
var rabbitMqSettings = new RabbitMqSettings();
builder.Configuration.GetSection(nameof(RabbitMqSettings)).Bind(rabbitMqSettings);
builder.Services.AddOptions<SmtpSettings>().BindConfiguration(nameof(SmtpSettings));

// Dependency injections
builder.Services.AddSingleton<IEmailService, EmailService>();

// Add MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add MassTransit service and configuration for RabbitMQ
builder.Services.AddMassTransitWithConfiguration(rabbitMqSettings);

// Add and configure entity framework database context + retry policy 
builder.Services.AddDbContext<ApplicationDataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), options =>
    {
        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
    });
});

var app = builder.Build();

app.Run();
