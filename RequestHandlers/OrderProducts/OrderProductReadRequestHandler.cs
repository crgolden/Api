namespace crgolden.Api.OrderProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductReadRequestHandler : ReadRequestHandler<OrderProductReadRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductReadRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
