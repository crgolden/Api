﻿namespace crgolden.Api.Orders
{
    using System.Threading;
    using System.Threading.Tasks;
    using Abstractions;
    using Microsoft.Extensions.Logging;

    public class OrderDeleteNotificationHandler : DeleteNotificationHandler<OrderDeleteNotification>
    {
        public OrderDeleteNotificationHandler(ILogger<OrderDeleteNotificationHandler> logger) : base(logger)
        {
        }

        public override Task Handle(OrderDeleteNotification notification, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}
