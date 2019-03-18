namespace Clarity.Api
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Serilog;
    using Serilog.Events;

    public class Program
    {
        // https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/#update-main-method-in-programcs
        public static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(
                    telemetryConfiguration: TelemetryConfiguration.Active,
                    telemetryConverter: TelemetryConverter.Traces)
                .WriteTo.File(
                    path: @"D:\home\LogFiles\Application\Clarity.Api.txt",
                    fileSizeLimitBytes: 1_000_000,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    rollOnFileSizeLimit: true)
                .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                using (var tokenSource = new CancellationTokenSource())
                {
                    var webHost = BuildWebHost(args);
                    await webHost.MigrateDatabaseAsync(tokenSource.Token);
                    await webHost.RunAsync(tokenSource.Token);
                    return 0;
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configBuilder => configBuilder.AddAzureKeyVault())
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
