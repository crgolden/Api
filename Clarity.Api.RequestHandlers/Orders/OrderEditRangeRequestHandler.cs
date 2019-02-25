namespace Clarity.Api.Orders
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderEditRangeRequestHandler : EditRangeRequestHandler<OrderEditRangeRequest, Order, OrderModel>
    {
        public OrderEditRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
