﻿namespace crgolden.Api.Products
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class ProductDeleteNotificationHandler : DeleteNotificationHandler<ProductDeleteNotification>
    {
        public ProductDeleteNotificationHandler(ILogger<ProductDeleteNotificationHandler> logger) : base(logger)
        {
        }

        public override Task Handle(ProductDeleteNotification notification, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
