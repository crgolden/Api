namespace Cef.API
{
    //using Core.Extensions;
    //using Core.Filters;
    //using Core.Interfaces;
    //using Core.Services;
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
            services.AddApplicationInsightsTelemetry(_configuration);
            //services.AddDatabase(_configuration);
            //services.AddScoped<ISeedService, SeedDataService>();
            //services.AddSingleton<IEmailSender, EmailSender>();
            //services.AddEmailOptions(_configuration);
            //services.AddPolicies();
            services.AddCors();
            services.AddMvc(/*setup => setup.Filters.Add(typeof(ModelStateFilter))*/)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    var identityServerAddress = _configuration.GetValue<string>("IdentityServerAddress");
                    if (string.IsNullOrEmpty(identityServerAddress)) return;

                    options.Authority = identityServerAddress;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                });
            //services.AddSwagger("Cef-API", "v1");
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
            //app.UseCors(_configuration);
            //app.UseSwagger("Cef-API v1");
            app.UseMvcWithDefaultRoute();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
        }
    }
}
