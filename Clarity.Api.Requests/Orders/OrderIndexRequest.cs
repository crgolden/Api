namespace Clarity.Api.Orders
{
    using System;
    using Core;
    using Kendo.Mvc.UI;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class OrderIndexRequest : IndexRequest
    {
        public Guid? UserId { get; set; }

        public OrderIndexRequest(ModelStateDictionary modelState = null, DataSourceRequest request = null)
            : base(modelState, request)
        {
        }
    }
}
