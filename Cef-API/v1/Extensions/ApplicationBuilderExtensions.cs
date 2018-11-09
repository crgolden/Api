namespace Cef_API.v1.Extensions
{
    using Options;
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static void UseCors(this IApplicationBuilder app, CorsOptions corsOptions)
        {
            app.UseCors(options => options
                .WithOrigins(corsOptions.Origins)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
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
