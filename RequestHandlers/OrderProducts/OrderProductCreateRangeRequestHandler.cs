namespace crgolden.Api.OrderProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class OrderProductCreateRangeRequestHandler : CreateRangeRequestHandler<OrderProductCreateRangeRequest, OrderProduct, OrderProductModel>
    {
        public OrderProductCreateRangeRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<(OrderProductModel[], object[][])> Handle(OrderProductCreateRangeRequest request, CancellationToken token)
        {
            var models = new OrderProductModel[request.Models.Length];
            var keyValues = new object[request.Models.Length][];
            for (var i = 0; i < request.Models.Length; i++)
            {
                var entity = Mapper.Map<OrderProduct>(request.Models[i]);
                var entityEntry = Context.Entry(entity);
                entityEntry.State = EntityState.Added;
                await entityEntry.Reference(x => x.Product).LoadAsync(token).ConfigureAwait(false);
                await entityEntry.Reference(x => x.Order).LoadAsync(token).ConfigureAwait(false);
                models[i] = Mapper.Map<OrderProductModel>(entity);
                keyValues[i] = new object[]{ request.Models[i].OrderId, request.Models[i].ProductId };
            }

            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            return (models, keyValues);
        }
    }
}
