namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Relationships;

    public class OrderProductsService : BaseRelationshipService<OrderProduct, Order, Product>
    {
        public OrderProductsService(DbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<OrderProduct>> Index()
        {
            return await base.Index();
        }

        public override async Task<OrderProduct> Details(Guid id1, Guid id2)
        {
            return await base.Details(id1, id2);
        }

        public override async Task<OrderProduct> Create(OrderProduct relationship)
        {
            return await base.Create(relationship);
        }

        public override async Task<List<OrderProduct>> CreateRange(List<OrderProduct> relationships)
        {
            return await base.CreateRange(relationships);
        }

        public override async Task Edit(OrderProduct relationship)
        {
            var orderProduct = await Context.FindAsync<OrderProduct>(relationship.Model1Id, relationship.Model2Id);
            var order = await Context.FindAsync<Order>(relationship.Model1Id);
            if (orderProduct != null && order != null)
            {
                order.Total -= orderProduct.ExtendedPrice;
                order.Total += relationship.ExtendedPrice;
                order.Updated = DateTime.Now;
                Context.Entry(orderProduct).State = EntityState.Detached;
                relationship.Updated = order.Updated;
                Context.Entry(relationship).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
        }

        public override async Task EditRange(List<OrderProduct> relationships)
        {
            await base.EditRange(relationships);
        }

#pragma warning disable 1998
        public override async Task Delete(Guid id1, Guid id2)
        {
        }
#pragma warning restore 1998
    }
}
