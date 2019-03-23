namespace Clarity.Api.Products
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.Extensions.Logging;
    using Nest;

    public class ProductReadNotificationHandler : ReadNotificationHandler<ProductReadNotification, ProductModel>
    {
        public ProductReadNotificationHandler(ILogger<ProductReadNotificationHandler> logger) : base(logger)
        {
        }

        public override async Task Handle(ProductReadNotification notification, CancellationToken token)
        {
            var client = new ElasticClient(new ConnectionSettings(new Uri("https://52.247.198.17:9200")));
            var response1a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response1b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"1a: {response1a.IsValid}");
            Console.WriteLine($"1b: {response1b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("https://52.247.198.17")));
            var response2a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response2b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"2a: {response2a.IsValid}");
            Console.WriteLine($"2b: {response2b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("http://52.247.198.17:9200")));
            var response3a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response3b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"3a: {response3a.IsValid}");
            Console.WriteLine($"3b: {response3b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("http://52.247.198.17")));
            var response4a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response4b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"4a: {response4a.IsValid}");
            Console.WriteLine($"4b: {response4b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("https://10.0.0.4:9200")));
            var response5a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response5b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"5a: {response5a.IsValid}");
            Console.WriteLine($"5b: {response5b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("https://10.0.0.4")));
            var response6a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response6b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"6a: {response6a.IsValid}");
            Console.WriteLine($"6b: {response6b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("http://10.0.0.4:9200")));
            var response7a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response7b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"7a: {response7a.IsValid}");
            Console.WriteLine($"7b: {response7b.IsValid}");
            client = new ElasticClient(new ConnectionSettings(new Uri("http://10.0.0.4")));
            var response8a = await client.AuthenticateAsync(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")), token);
            var response8b = await client.AuthenticateAsync(cancellationToken: token);
            Console.WriteLine($"8a: {response8a.IsValid}");
            Console.WriteLine($"8b: {response8b.IsValid}");
            await base.Handle(notification, token);
        }
    }
}
