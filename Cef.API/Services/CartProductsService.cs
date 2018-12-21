namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Relationships;

    public class CartProductsService : BaseRelationshipService<CartProduct, Cart, Product>
    {
        public CartProductsService(DbContext context) : base(context)
        {
        }

        public override IEnumerable<CartProduct> Index()
        {
            return base.Index();
        }

        public override async Task<CartProduct> Details(Guid id1, Guid id2)
        {
            return await base.Details(id1, id2);
        }

        public override async Task<CartProduct> Create(CartProduct relationship)
        {
            return await base.Create(relationship);
        }

        public override async Task Edit(CartProduct relationship)
        {
            var entity = await Context.Set<CartProduct>().SingleOrDefaultAsync(x =>
                x.Model1Id.Equals(relationship.Model1Id) &&
                x.Model2Id.Equals(relationship.Model2Id));
            if (entity != null)
            {
                entity.Quantity = relationship.Quantity;
            }
            await Context.SaveChangesAsync();
        }

        public override async Task Delete(Guid id1, Guid id2)
        {
            await base.Delete(id1, id2);
        }
    }
}
