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

        public override async Task<IEnumerable<Cart>> Index()
        {
            return await base.Index();
        }

        public override async Task<Cart> Details(Guid id)
        {
            return await Context.Set<Cart>()
                .Include(x => x.CartProducts)
                .SingleOrDefaultAsync(x => x.Id.Equals(id) || x.UserId.HasValue && x.UserId.Value.Equals(id));
        }

        public override async Task<Cart> Create(Cart model)
        {
            Cart cart = null;
            if (model.UserId != null && !model.UserId.Equals(Guid.Empty))
            {
                cart = await Context.Set<Cart>()
                    .Include(x => x.CartProducts)
                    .SingleOrDefaultAsync(x => x.UserId == model.UserId);
            }

            if (cart == null)
            {
                model.Created = model.Created > DateTime.MinValue
                    ? model.Created
                    : DateTime.Now;
                foreach (var cartProduct in model.CartProducts)
                {
                    cartProduct.Created = model.Created;
                }

                model.Total = model.CartProducts.Sum(x => x.ExtendedPrice);
                Context.Add(model);
                await Context.SaveChangesAsync();
                return model;
            }

            cart.Updated = DateTime.Now;
            foreach (var modelCartProduct in model.CartProducts)
            {
                var cartProduct = cart.CartProducts.SingleOrDefault(x => x.Model2Id.Equals(modelCartProduct.Model2Id));
                if (cartProduct != null)
                {
                    cartProduct.Price = modelCartProduct.Price;
                    cartProduct.Quantity = modelCartProduct.Quantity;
                    cartProduct.Updated = cartProduct.Updated;
                }
                else
                {
                    modelCartProduct.Created = cart.Updated.Value;
                    cart.CartProducts.Add(modelCartProduct);
                }
            }

            cart.Total = cart.CartProducts.Sum(x => x.ExtendedPrice);
            await Context.SaveChangesAsync();
            return cart;
        }

        public override async Task<List<Cart>> CreateRange(List<Cart> models)
        {
            return await base.CreateRange(models);
        }

        public override async Task Edit(Cart model)
        {
            model.Updated = model.Updated ?? DateTime.Now;
            if (model.UserId.HasValue)
            {
                var cart = await Context.Set<Cart>()
                    .Include(x => x.CartProducts)
                    .SingleOrDefaultAsync(x => x.UserId.Equals(model.UserId.Value));
                if (cart != null)
                {
                    if (!cart.Id.Equals(model.Id))
                    {
                        foreach (var cartProduct in cart.CartProducts.Where(x => !model.CartProducts.Any(y => x.Model2Id.Equals(y.Model2Id))))
                        {
                            cartProduct.Updated = model.Updated;
                            model.CartProducts.Add(cartProduct);
                        }

                        Context.Remove(cart);
                    }
                    else
                    {
                        Context.Entry(cart).State = EntityState.Detached;
                    }
                }
            }

            var cartProducts = Context.Set<CartProduct>().Where(x => x.Model1Id.Equals(model.Id));
            foreach (var cartProduct in model.CartProducts)
            {
                var existing = await cartProducts.SingleOrDefaultAsync(x => x.Model2Id.Equals(cartProduct.Model2Id));
                if (existing != null)
                {
                    if (existing.Quantity == cartProduct.Quantity) continue;
                    existing.Quantity = cartProduct.Quantity;
                    existing.Updated = model.Updated;
                }
                else
                {
                    cartProduct.Created = model.Updated.Value;
                    Context.Add(cartProduct);
                }
            }

            foreach (var cartProduct in cartProducts.Where(x => !model.CartProducts.Any(y => x.Model2Id.Equals(y.Model2Id))))
            {
                Context.Remove(cartProduct);
            }

            model.Total = model.CartProducts.Sum(x => x.ExtendedPrice);
            Context.Entry(model).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public override async Task EditRange(List<Cart> models)
        {
            await base.EditRange(models);
        }

#pragma warning disable 1998
        public override async Task Delete(Guid id)
        {
        }
#pragma warning restore 1998
    }
}
