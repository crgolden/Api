namespace Clarity.Api
{
    using Core;

    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductModel>();
        }
    }
}
