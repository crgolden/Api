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

        public override Task Handle(ProductReadNotification notification, CancellationToken token)
        {
            var client1 = new ElasticClient(new ConnectionSettings(new Uri("https://52.247.198.17:9200")));
            var response1a = client1.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response1b = client1.Authenticate();
            Console.WriteLine(response1a.IsValid);
            Console.WriteLine(response1b.IsValid);
            var client2 = new ElasticClient(new ConnectionSettings(new Uri("https://52.247.198.17")));
            var response2a = client2.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response2b = client2.Authenticate();
            Console.WriteLine(response2a.IsValid);
            Console.WriteLine(response2b.IsValid);
            var client3 = new ElasticClient(new ConnectionSettings(new Uri("http://52.247.198.17:9200")));
            var response3a = client3.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response3b = client3.Authenticate();
            Console.WriteLine(response3a.IsValid);
            Console.WriteLine(response3b.IsValid);
            var client4 = new ElasticClient(new ConnectionSettings(new Uri("http://52.247.198.17")));
            var response4a = client4.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response4b = client4.Authenticate();
            Console.WriteLine(response4a.IsValid);
            Console.WriteLine(response4b.IsValid);
            var client5 = new ElasticClient(new ConnectionSettings(new Uri("https://10.0.0.4:9200")));
            var response5a = client5.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response5b = client5.Authenticate();
            Console.WriteLine(response5a.IsValid);
            Console.WriteLine(response5b.IsValid);
            var client6 = new ElasticClient(new ConnectionSettings(new Uri("https://10.0.0.4")));
            var response6a = client6.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response6b = client6.Authenticate();
            Console.WriteLine(response6a.IsValid);
            Console.WriteLine(response6b.IsValid);
            var client7 = new ElasticClient(new ConnectionSettings(new Uri("http://10.0.0.4:9200")));
            var response7a = client7.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response7b = client7.Authenticate();
            Console.WriteLine(response7a.IsValid);
            Console.WriteLine(response7b.IsValid);
            var client8 = new ElasticClient(new ConnectionSettings(new Uri("http://10.0.0.4")));
            var response8a = client8.Authenticate(x => x.RequestConfiguration(y => y.BasicAuthentication("elastic", "kGRKd8x9Yw1FQm%O")));
            var response8b = client8.Authenticate();
            Console.WriteLine(response8a.IsValid);
            Console.WriteLine(response8b.IsValid);
            return base.Handle(notification, token);
        }
    }
}
