namespace crgolden.Api.OrderProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductUpdateRangeRequestHandler : UpdateRangeRequestHandler<OrderProductUpdateRangeRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductUpdateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
