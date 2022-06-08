using Microsoft.OpenApi.Models;

namespace API
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                    Enter 'Bearer' [space] and then your token in the text input below.
                    \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce Api", Version = "v1",
            Description = "E-commerce APIs for developers to browse through." +
            "They are available for adding orders, shipping, tracking, getting products," +
            " viewing, buying and selling and other tasks." +
            "The Stripe API uses API keys to authenticate requests." +
            "You can view and manage your API keys in the Stripe Dashboard." +
            "Test mode secret keys have the prefix sk_test_ and publishable keys have prefix pk_test_. " +
            "Use your own keys in appsettings.json to authenticate requests while creating order"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce Api v1");
            });

            return app;
        }
    }
}
