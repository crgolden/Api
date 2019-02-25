namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductDetailsRequestHandler : DetailsRequestHandler<OrderProductDetailsRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductDetailsRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
