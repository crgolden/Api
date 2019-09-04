namespace crgolden.Api
{
    using System.Reflection;
    using AutoMapper;
    using Core;
    using Shared;
    using MediatR;
    using Microsoft.ApplicationInsights.AspNetCore;
    using Microsoft.ApplicationInsights.SnapshotCollector;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Batch;
    using Microsoft.AspNet.OData.Builder;
    using Microsoft.AspNet.OData.Extensions;
    using Microsoft.AspNet.OData.Query;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.OData;
    using Swashbuckle.AspNetCore.SwaggerGen;

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
                .AddDbContext<ApiDbContext>(_configuration.GetDbContextOptions(assemblyName: "Api.Data"))
                .Configure<SnapshotCollectorConfiguration>(_configuration.GetSection(nameof(SnapshotCollectorConfiguration)))
                .Configure<EmailOptions>(_configuration.GetSection(nameof(EmailOptions)))
                .Configure<PaymentOptions>(_configuration.GetSection(nameof(PaymentOptions)))
                .Configure<StorageOptions>(_configuration.GetSection(nameof(StorageOptions)))
                .Configure<ValidationOptions>(_configuration.GetSection(nameof(ValidationOptions)))
                .Configure<CorsOptions>(_configuration.GetSection(nameof(CorsOptions)))
                .Configure<DatabaseOptions>(_configuration.GetSection(nameof(DatabaseOptions)))
                .Configure<ServiceBusOptions>(_configuration.GetSection(nameof(ServiceBusOptions)))
                .Configure<CacheOptions>(_configuration.GetSection(nameof(CacheOptions)))
                .Configure<Shared.ApiExplorerOptions>(_configuration.GetSection(nameof(Shared.ApiExplorerOptions)))
                .AddScoped<DbContext, ApiDbContext>()
                .AddMemoryCache()
                .AddSingleton<IPaymentService, StripePaymentService>()
                .AddSingleton<IStorageService, AzureBlobStorageService>()
                .AddSingleton<IValidationService<Address>, SmartyStreetsValidationService>()
                .AddSingleton<IEmailService, SendGridEmailService>()
                .AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp))
                .AddSingleton<IQueueClient, EmailQueueClient>()
                .AddMediatR(assemblies: new[]
                {
                    Assembly.Load("Api.RequestHandlers"),
                    Assembly.Load("Api.NotificationHandlers")
                })
                .AddAutoMapper(assemblies: new[]
                {
                    Assembly.Load("Abstractions.Profiles"),
                    Assembly.Load("Api.Profiles")
                })
                .AddCors();
            services.AddHealthChecks();
            services.AddHttpClient<IDemoFilesClient, TelerikDemoFilesClient>();
            services.AddMvc(options =>
                {
                    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
                    options.Filters.Add<ModelStateActionFilter>();
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddApiVersioning(options => options.ReportApiVersions = true)
                .AddOData()
                .EnableApiVersioning();
            services.AddODataQueryFilter().AddODataApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
                options.QueryOptions.Controller<CartsController>()
                    .Action(c => c.List(default))
                    .Allow(AllowedQueryOptions.All)
                    .AllowTop(0)
                    .AllowOrderBy();
            });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerGenConfiguration>()
                .AddSwaggerGen(options =>
                {
                    options.OperationFilter<ParameterDescriptionsOperationFilter>();
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                });
            services.AddIdentityServerAuthentication(_configuration, "api1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            VersionedODataModelBuilder modelBuilder,
            IApiVersionDescriptionProvider provider,
            IMapper mapper,
            IOptions<CorsOptions> corsOptions,
            IOptions<Shared.ApiExplorerOptions> apiExplorerOptions)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage().UseDatabaseErrorPage();
            if (env.IsProduction()) app.UseHsts();

            app.UseHttpsRedirection()
                .UseAuthentication()
                .UseHealthChecks("/health")
                .UseCors(corsOptions.Value)
                .UseMvc(routeBuilder =>
                {
                    routeBuilder.ServiceProvider.GetRequiredService<ODataOptions>().UrlKeyDelimiter = ODataUrlKeyDelimiter.Parentheses;
                    routeBuilder
                        .Select()
                        .Filter()
                        .OrderBy()
                        .Expand()
                        .Count()
                        .MaxTop(10)
                        .SkipToken()
                        .MapVersionedODataRoutes(
                            routeName: "odata",
                            routePrefix: "api",
                            models: modelBuilder.GetEdmModels(),
                            newBatchHandler: () => new DefaultODataBatchHandler());
                })
                .UseODataBatching()
                .UseSwagger(provider, apiExplorerOptions);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
