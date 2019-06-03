namespace crgolden.Api.Orders
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderUpdateRequestHandler : UpdateRequestHandler<OrderUpdateRequest, Order, OrderModel>
    {
        public OrderUpdateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
