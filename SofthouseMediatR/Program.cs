using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SofthouseMediatR.DataContext;
using SofthouseMediatR.Mappings;
using SofthouseMediatR.Repositories.Interfaces;
using SofthouseMediatR.Services;
using SofthouseMediatR.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // These settings add "Authorization" button in Swagger and defined how you want to authorize
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        Description = "Please enter a valid token",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

// Add data context
builder.Services.AddDbContext<ApplicationDataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add Authentication
builder.Services
     .AddAuthentication()
     .AddBearerToken();

// Add Authorization
builder.Services.AddAuthorization();

// By using this service you can easily add some of the endpoints of Identity to Swagger automatically
builder.Services
    .AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDataContext>();

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

// Add .Net Identity API endpoints
app.MapGroup("api/auth")
    .MapIdentityApi<IdentityUser>()
    .WithOpenApi();

// Add Authorization middleware
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
