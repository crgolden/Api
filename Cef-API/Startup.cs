namespace Cef_API
{
    using System.Threading.Tasks;
    using Cef_API.Core.v1.Models;
    using v1.Data;
    using v1.Extensions;
    using v1.Filters;
    using v1.Interfaces;
    using v1.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

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
            services.AddDatabase(_configuration);
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<ISeedDataService, SeedDataService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddUsersOptions(_configuration);
            services.AddAuthentication(_configuration);
            services.AddPolicies();
            services.AddMvc(setup => setup.Filters.Add(typeof(ModelStateFilter)))
                .AddJsonOptions(setup =>
                {
                    setup.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddSwagger("Cef-API", "v1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            DbContext context, ISeedDataService seedDataService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            context.Database.Migrate();
            Task.Run(seedDataService.SeedDatabase).Wait();

            loggerFactory.AddAzureWebAppDiagnostics();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
        }
    }
}
