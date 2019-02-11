namespace Cef.API.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Claims;
    using Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    var identityServerAddress = configuration.GetValue<string>("IdentityServerAddress");
                    if (string.IsNullOrEmpty(identityServerAddress)) return;

                    options.Authority = identityServerAddress;
                    options.ApiName = "api1";
                    options.RoleClaimType = ClaimTypes.Role;
                });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Info
                {
                    Title = "Cef-API",
                    Version = "v1"
                });
                setup.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Type = "apiKey",
                    In = "Header",
                    Name = "Authorization",
                    Description = "Input \"Bearer {token}\" (without quotes)"
                });
                setup.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}
