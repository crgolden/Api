namespace Clarity.Api.Orders
{
    using System;
    using Abstractions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderListRequest : ListRequest<Order, OrderModel>
    {
        public Guid? UserId { get; set; }

        public OrderListRequest(ModelStateDictionary modelState, DataSourceRequest request) : base(modelState, request)
        {
        }
    }
}
