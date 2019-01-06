namespace Cef.API
{
    using Core.Extensions;
    using Core.Factories;
    using Core.Filters;
    using Core.Interfaces;
    using Core.Options;
    using Core.Services;
    using Core.Transformers;
    using Data;
    using Extensions;
    using Microsoft.ApplicationInsights.AspNetCore;
    using Microsoft.ApplicationInsights.SnapshotCollector;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Models;
    using Options;
    using Relationships;
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
            services.AddDbContext<ApiDbContext>(_configuration.GetDbContextOptions());
            services.Configure<SnapshotCollectorConfiguration>(_configuration.GetSection(nameof(SnapshotCollectorConfiguration)));
            services.Configure<EmailOptions>(_configuration.GetSection(nameof(EmailOptions)));
            services.Configure<PaymentOptions>(_configuration.GetSection(nameof(PaymentOptions)));
            services.Configure<StorageOptions>(_configuration.GetSection(nameof(StorageOptions)));
            services.Configure<ValidationOptions>(_configuration.GetSection(nameof(ValidationOptions)));
            services.AddScoped<DbContext, ApiDbContext>();
            services.AddScoped<ISeedService, SeedDataService>();
            services.AddScoped<IModelService<Payment>, StripePaymentsService>();
            services.AddScoped<IModelService<Product>, ProductsService>();
            services.AddScoped<IModelService<Order>, OrdersService>();
            services.AddScoped<IModelService<Cart>, CartsService>();
            services.AddScoped<IModelService<File>, FilesService>();
            services.AddScoped<IModelService<Category>, CategoriesService>();
            services.AddScoped<IRelationshipService<CartProduct, Cart, Product>, CartProductsService>();
            services.AddScoped<IRelationshipService<OrderProduct, Order, Product>, OrderProductsService>();
            services.AddScoped<IRelationshipService<ProductFile, Product, File>, ProductFilesService>();
            services.AddSingleton<IEmailSender, SendGridEmailSender>();
            services.AddSingleton<ITelemetryProcessorFactory>(sp => new SnapshotCollectorTelemetryProcessorFactory(sp));
            services.AddCors();
            services.AddMvc(setup =>
                {
                    setup.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
                    setup.Filters.Add(typeof(ModelStateFilter));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAuthentication(_configuration);
            services.AddSwagger();
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
            app.UseSwagger();
            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Cef-API v1");
                setup.RoutePrefix = string.Empty;
                setup.DocumentTitle = "Cef-API v1";
            });
            app.UseMvcWithDefaultRoute();

            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
        }
    }
}
