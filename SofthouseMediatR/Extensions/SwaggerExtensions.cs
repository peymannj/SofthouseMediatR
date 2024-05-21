using Microsoft.OpenApi.Models;

namespace SofthouseMediatR.Extensions;

public static class SwaggerExtensions
{
	public static IServiceCollection AddSwaggerWithConfiguration(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(options =>
		{
			// These settings add "Authorization" button in Swagger and defined how you want to authorize
			// You just need to use a generated accesstoken.
			options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer",
				BearerFormat = "JWT",
				Name = "Authorization",
				Description = "Please enter a valid token"
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
			
			// Another way to show the authorization button, but you need to use the 
			// accesstoken with Bearer prefix in the field. Ex: Bearer xxxxxx-xxxxxx
			// options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
			// {
			// 	In = ParameterLocation.Header,
			// 	Type = SecuritySchemeType.ApiKey,
			// 	Name = "Authorization"
			// });
			//
			// options.OperationFilter<SecurityRequirementsOperationFilter>();
		});

		return services;
	}
}
