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

        public static void UseSwagger(this IApplicationBuilder app, string title)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", title);
                setup.RoutePrefix = string.Empty;
                setup.DocumentTitle = title;
            });
        }
    }
}
