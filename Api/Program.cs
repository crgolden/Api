﻿namespace crgolden.Api
{
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public class Program
    {
        // https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/#update-main-method-in-programcs
        public static async Task Main(string[] args)
        {
            using (var tokenSource = new CancellationTokenSource())
            using (var webHost = await BuildWebHost(args).MigrateDatabaseAsync(tokenSource.Token))
                await webHost.RunAsync(tokenSource.Token);
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configBuilder => configBuilder.AddAzureKeyVault())
                .UseStartup<Startup>()
                .UseSerilog("crgolden.Api", true)
                .Build();
    }
}
