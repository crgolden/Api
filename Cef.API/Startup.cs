namespace Cef.API
{
    using Core.Extensions;
    using Core.Factories;
    using Core.Filters;
    using Core.Interfaces;
    using Core.Options;
    using Core.Services;
    using Extensions;
    using Microsoft.ApplicationInsights.AspNetCore;
    using Microsoft.ApplicationInsights.SnapshotCollector;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Services;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SnapshotCollectorConfiguration>(_configuration.GetSection(nameof(SnapshotCollectorConfiguration)));
            services.Configure<EmailOptions>(_configuration.GetSection(nameof(EmailOptions)));
            services.AddApplicationInsightsTelemetry(_configuration);
            services.AddDatabase(_configuration);
            services.AddScoped<ISeedService, SeedDataService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp));
            services.AddCors();
            services.AddMvc(setup => setup.Filters.Add(typeof(ModelStateFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(_configuration);
            services.AddSwagger("Cef-API", "v1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            if (env.IsProduction())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(_configuration);
            app.UseSwagger("Cef-API v1");
            app.UseMvcWithDefaultRoute();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
        }
    }
}
