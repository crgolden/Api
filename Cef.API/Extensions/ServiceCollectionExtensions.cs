namespace Cef.API.Extensions
{
    using IdentityServer4.AccessTokenValidation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var identityServerAddress = configuration.GetValue<string>("IdentityServerAddress");
            if (!string.IsNullOrEmpty(identityServerAddress))
            {
                services
                    .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                    })
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = identityServerAddress;
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "api1";
                    });
            }
        }
    }
}
