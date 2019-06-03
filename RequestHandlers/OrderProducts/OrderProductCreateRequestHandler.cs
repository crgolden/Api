namespace crgolden.Api.OrderProducts
{
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRequestHandler : CreateRequestHandler<OrderProductCreateRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
