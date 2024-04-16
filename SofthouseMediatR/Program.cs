using Microsoft.EntityFrameworkCore;
using SofthouseMediatR.DataContext;
using SofthouseMediatR.Mappings;
using SofthouseMediatR.Repositories.Interfaces;
using SofthouseMediatR.Services;
using SofthouseMediatR.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add data context
builder.Services.AddDbContext<ApplicationDataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Dependency injections
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddTransient<ICarService, CarService>();

// Add MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add controller service
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers with support of OpenApi
// app.MapControllerRoute("default", pattern: "{controller=Home}/{action=Index}/{id?}").WithOpenApi();
// or easiest way
app.MapControllers()
    .WithOpenApi();

app.UseHttpsRedirection();

app.Run();
