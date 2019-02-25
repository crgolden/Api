namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRequestHandler : CreateRequestHandler<OrderProductCreateRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
