using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.DataContext;
using SofthouseMediatR.Extensions;
using SofthouseMediatR.Mappings;
using SofthouseMediatR.Repositories.Interfaces;
using SofthouseMediatR.Services;
using SofthouseMediatR.Services.Interfaces;
using SofthouseMediatR.Settings;
using SofthouseWorker.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Map settings
var rabbitMqSettings = new RabbitMqSettings();
builder.Configuration.GetSection(nameof(RabbitMqSettings)).Bind(rabbitMqSettings);
builder.Services.AddOptions<SmtpSettings>().BindConfiguration(nameof(SmtpSettings));

// Dependency injections
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IMessagingService, MessagingService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityEmailService>();

// Swagger settings
builder.Services.AddSwaggerWithConfiguration();

// Add and configure entity framework database context + retry policy 
builder.Services.AddDbContext<ApplicationDataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), options =>
    {
        options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
    });
});

// By using this service you can easily configure role-based Identity
// and add some of the endpoints of Identity to Swagger automatically
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDataContext>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add MassTransit service and configuration for RabbitMQ and EF outbox
builder.Services.AddMassTransitWithConfiguration(rabbitMqSettings);

// Add controller service
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add .Net Identity API endpoints
app.MapGroup("api/auth")
    .MapIdentityApi<IdentityUser>()
    .WithOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
