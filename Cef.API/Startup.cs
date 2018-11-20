namespace Cef.API
{
    using Core.Extensions;
    using Core.Filters;
    using Core.Interfaces;
    using Core.Options;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
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
            services.AddDatabase(_configuration);
            services.AddMvc(setup => setup.Filters.Add(typeof(ModelStateFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var identityServerAddress = _configuration.GetValue<string>("IdentityServerAddress");
            if (!string.IsNullOrEmpty(identityServerAddress))
            {
                services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = identityServerAddress;
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "api1";
                    });
            }
            // services.AddIdentity<User, Role>(setup => setup.SignIn.RequireConfirmedEmail = true)
            //     .AddEntityFrameworkStores<CefDbContext>()
            //     .AddDefaultTokenProviders();
            // services.AddAuthenticationOptions(_configuration);
            //services.AddEmailOptions(_configuration);
            //services.AddSingleton<IEmailSender, EmailSender>();
            // services.AddUserOptions(_configuration);
            services.AddScoped<ISeedService, SeedDataService>();
            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            // services.ConfigureApplicationCookie(options => options.Cookie = new CookieBuilder
            // {
            //     SameSite = SameSiteMode.None,
            //     Expiration = System.TimeSpan.FromDays(30)
            // });
            // services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.AddPolicies();
            // services.AddMvc(setup => setup.Filters.Add(typeof(ModelStateFilter)))
            //     .AddJsonOptions(setup =>
            //     {
            //         setup.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            //         setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //     })
            //     .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCorsOptions(_configuration);
            services.AddCors();
            services.AddSwagger("Cef-API", "v1");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IOptions<CorsOptions> corsOptions)
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
            //app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseCors(corsOptions.Value);
            app.UseSwagger("Cef-API v1");
            app.UseMvcWithDefaultRoute();

            loggerFactory.AddAzureWebAppDiagnostics();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Warning);
        }
    }
}
