namespace Clarity.Api.OrderProducts
{
    using AutoMapper;
    using Core;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductEditRequestHandler : EditRequestHandler<OrderProductEditRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductEditRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
