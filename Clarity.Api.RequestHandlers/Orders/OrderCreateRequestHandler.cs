namespace Clarity.Api.Orders
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderCreateRequestHandler : CreateRequestHandler<OrderCreateRequest, Order, OrderModel>
    {
        public OrderCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
