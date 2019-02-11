namespace Cef.API.Extensions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;

    [ExcludeFromCodeCoverage]
    public static class ApplicationBuilderExtensions
    {
        public static void UseCors(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsOrigins = new List<string>();
            var angularClientAddress = configuration.GetValue<string>("AngularClientAddress");
            if (!string.IsNullOrEmpty(angularClientAddress)) corsOrigins.Add(angularClientAddress);

            app.UseCors(options => options
                .WithOrigins(corsOrigins.ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        }
    }
}
