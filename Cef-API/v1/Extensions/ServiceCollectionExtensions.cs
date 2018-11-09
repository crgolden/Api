namespace Cef_API.v1.Extensions
{
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;
    using Data;
    using Filters;
    using Options;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;

    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var sqlServerOptionsSection = configuration.GetSection(nameof(SqlServerOptions));
                if (!sqlServerOptionsSection.Exists())
                {
                    return;
                }

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    var sqlServerOptions = sqlServerOptionsSection.Get<SqlServerOptions>();
                    var builder = new SqlConnectionStringBuilder
                    {
                        ConnectTimeout = sqlServerOptions.ConnectTimeout,
                        DataSource = sqlServerOptions.DataSource,
                        Encrypt = sqlServerOptions.Encrypt,
                        InitialCatalog = sqlServerOptions.InitialCatalog,
                        IntegratedSecurity = sqlServerOptions.IntegratedSecurity,
                        MultipleActiveResultSets = sqlServerOptions.MultipleActiveResultSets,
                        PersistSecurityInfo = sqlServerOptions.PersistSecurityInfo,
                        TrustServerCertificate = sqlServerOptions.TrustServerCertificate,
                    };
                    if (!builder.IntegratedSecurity)
                    {
                        builder.Password = sqlServerOptions.Password;
                        builder.UserID = sqlServerOptions.UserId;
                    }

                    options.UseSqlServer(builder.ConnectionString).UseLazyLoadingProxies();
                });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var sqLiteOptionsSection = configuration.GetSection(nameof(SqLiteOptions));
                if (!sqLiteOptionsSection.Exists())
                {
                    return;
                }

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    var sqLiteOptions = sqLiteOptionsSection.Get<SqLiteOptions>();
                    var connectionString = $"Data Source={sqLiteOptions.Path}/{sqLiteOptions.Name}.db";
                    options.UseSqlite(connectionString).UseLazyLoadingProxies();
                });
            }
        }

        public static void AddCorsOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var corsOptionsSection = configuration.GetSection(nameof(CorsOptions));
            if (!corsOptionsSection.Exists())
            {
                return;
            }

            services.Configure<CorsOptions>(options =>
            {
                var corsOptions = corsOptionsSection.Get<CorsOptions>();
                options.Origins = corsOptions.Origins;
            });
        }

        public static void AddUsersOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var usersOptionsSection = configuration.GetSection(nameof(UsersOptions));
            if (!usersOptionsSection.Exists())
            {
                return;
            }

            services.Configure<UsersOptions>(options =>
            {
                var usersOptions = usersOptionsSection.Get<UsersOptions>();
                options.Users = usersOptions.Users;
            });
        }

        public static void AddEmailOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var emailOptionsSection = configuration.GetSection(nameof(EmailOptions));
            if (!emailOptionsSection.Exists())
            {
                return;
            }

            services.Configure<EmailOptions>(options =>
            {
                var emailOptions = emailOptionsSection.Get<EmailOptions>();
                options.ApiKey = emailOptions.ApiKey;
                options.Email = emailOptions.Email;
                options.Name = emailOptions.Name;
            });
        }

        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
            });
        }

        public static void AddSwagger(this IServiceCollection services, string title, string version)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(version, new Info
                {
                    Title = title,
                    Version = version
                });
                setup.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Type = "apiKey",
                    In = "Header",
                    Name = "Authorization",
                    Description = "Input \"Bearer {token}\" (without quotes)"
                });
                setup.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}
