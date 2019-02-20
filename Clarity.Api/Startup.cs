namespace Clarity.Api
{
    using System.Reflection;
    using Core;
    using MediatR;
    using Microsoft.ApplicationInsights.AspNetCore;
    using Microsoft.ApplicationInsights.SnapshotCollector;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

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
            services.AddDbContext<ApiDbContext>(_configuration.GetDbContextOptions("Clarity.Api.Data"));
            services.Configure<SnapshotCollectorConfiguration>(_configuration.GetSection(nameof(SnapshotCollectorConfiguration)));
            services.Configure<EmailOptions>(_configuration.GetSection(nameof(EmailOptions)));
            services.Configure<PaymentOptions>(_configuration.GetSection(nameof(PaymentOptions)));
            services.Configure<StorageOptions>(_configuration.GetSection(nameof(StorageOptions)));
            services.Configure<AddressOptions>(_configuration.GetSection(nameof(AddressOptions)));
            services.Configure<CorsOptions>(_configuration.GetSection(nameof(CorsOptions)));
            services.AddScoped<DbContext, ApiDbContext>();
            services.AddScoped<ISeedService, SeedDataService>();
            services.AddSingleton<IEmailService, SendGridEmailService>();
            services.AddSingleton<IPaymentService, StripePaymentService>();
            services.AddSingleton<IStorageService, AzureBlobStorageService>();
            services.AddSingleton<IAddressService, SmartyStreetsAddressService>();
            services.AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp));
            services.AddMediatR(Assembly.Load("Clarity.Api.RequestHandlers"));
            services.AddHealthChecks();
            services.AddCors();
            services.AddMvc(setup =>
                {
                    setup.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
                    setup.Filters.Add<ModelStateActionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddIdentityServerAuthentication(_configuration, "api1");
            services.AddSwagger("Clarity-API", "v1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<CorsOptions> corsOptions)
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
            app.UseHealthChecks("/health");
            app.UseCors(corsOptions);
            app.UseSwagger("Clarity-API v1");
            app.UseMvcWithDefaultRoute();
        }
    }
}
