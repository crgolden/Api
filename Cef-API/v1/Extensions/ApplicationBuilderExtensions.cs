namespace Cef_API.v1.Extensions
{
    using Options;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    public static class ApplicationBuilderExtensions
    {
        public static void UseCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsOptionsSection = configuration.GetSection(nameof(CorsOptions));
            if (!corsOptionsSection.Exists())
            {
                return;
            }

            var corsOptions = corsOptionsSection.Get<CorsOptions>();
            app.UseCors(options => options
                .WithOrigins(corsOptions.Origins)
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
    }
}
