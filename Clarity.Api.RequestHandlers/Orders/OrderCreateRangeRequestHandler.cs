namespace Clarity.Api.Orders
{
    using System.Collections.Generic;
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderCreateRangeRequestHandler : CreateRangeRequestHandler<OrderCreateRangeRequest, IEnumerable<OrderModel>, Order, OrderModel>
    {
        public OrderCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
