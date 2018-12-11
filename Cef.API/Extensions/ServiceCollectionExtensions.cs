namespace Cef.API.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("api1", options =>
                {
                    var identityServerAddress = configuration.GetValue<string>("IdentityServerAddress");
                    if (string.IsNullOrEmpty(identityServerAddress)) return;

                    options.Authority = identityServerAddress;
                    options.ApiName = "api1";
                });
        }
    }
}
