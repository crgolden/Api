namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Services;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Relationships;

    public class CartsService : BaseModelService<Cart>
    {
        public CartsService(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Cart> Index()
        {
            return base.Index();
        }

        public override async Task<Cart> Details(Guid id)
        {
            return await Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public override async Task<Cart> Create(Cart model)
        {
            return await base.Create(model);
        }

        public override async Task Edit(Cart model)
        {
            var cartProducts = Context.Set<CartProduct>().Where(x => x.Model1Id.Equals(model.Id));
            foreach (var cartProduct in model.CartProducts)
            {
                var existing = cartProducts.SingleOrDefault(x => x.Model2Id.Equals(cartProduct.Model2Id));
                if (existing != null)
                {
                    existing.Quantity = cartProduct.Quantity;
                }
                else
                {
                    Context.Add(cartProduct);
                }
            }

            foreach (var cartProduct in cartProducts)
            {
                if (!model.CartProducts.Any(x => x.Model2Id.Equals(cartProduct.Model2Id)))
                {
                    Context.Remove(cartProduct);
                }
            }

            await base.Edit(model);
        }

        public override async Task Delete(Guid id)
        {
            await base.Delete(id);
        }
    }
}
