namespace Clarity.Api
{
    using System.Reflection;
    using AutoMapper;
    using Core;
    using MediatR;
    using Microsoft.ApplicationInsights.AspNetCore;
    using Microsoft.ApplicationInsights.SnapshotCollector;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.Azure.ServiceBus;
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
            services.AddApplicationInsightsTelemetry(_configuration)
                .AddDbContext<ApiDbContext>(_configuration.GetDbContextOptions(assemblyName: "Clarity.Api.Data"))
                .Configure<SnapshotCollectorConfiguration>(_configuration.GetSection(nameof(SnapshotCollectorConfiguration)))
                .Configure<EmailOptions>(_configuration.GetSection(nameof(EmailOptions)))
                .Configure<PaymentOptions>(_configuration.GetSection(nameof(PaymentOptions)))
                .Configure<StorageOptions>(_configuration.GetSection(nameof(StorageOptions)))
                .Configure<AddressOptions>(_configuration.GetSection(nameof(AddressOptions)))
                .Configure<CorsOptions>(_configuration.GetSection(nameof(CorsOptions)))
                .Configure<DatabaseOptions>(_configuration.GetSection(nameof(DatabaseOptions)))
                .Configure<ServiceBusOptions>(_configuration.GetSection(nameof(ServiceBusOptions)))
                .AddScoped<DbContext, ApiDbContext>()
                .AddSingleton<IPaymentService, StripePaymentService>()
                .AddSingleton<IStorageService, AzureBlobStorageService>()
                .AddSingleton<IValidationService<Address>, SmartyStreetsValidationService>()
                .AddSingleton<IEmailService, SendGridEmailService>()
                .AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp))
                .AddSingleton<IQueueClient, EmailQueueClient>()
                .AddMediatR(assemblies: new[]
                {
                    Assembly.Load("Clarity.Api.RequestHandlers"),
                    Assembly.Load("Clarity.Api.NotificationHandlers")

                })
                .AddAutoMapper(assemblies: new []
                {
                    Assembly.Load("Clarity.Api.Profiles")
                })
                .AddCors()
                .AddSwagger("Clarity-API", "v1");
            services.AddHealthChecks();
            services.AddHttpClient<IDemoFilesClient, TelerikDemoFilesClient>();
            services.AddMvc(setup =>
                {
                    setup.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
                    setup.Filters.Add<ModelStateActionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddIdentityServerAuthentication(_configuration, "api1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IMapper mapper,
            IOptions<CorsOptions> corsOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage().UseDatabaseErrorPage();
            }

            if (env.IsProduction())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection()
                .UseAuthentication()
                .UseHealthChecks("/health")
                .UseCors(corsOptions.Value)
                .UseSwagger("Clarity-API v1")
                .UseMvcWithDefaultRoute();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
