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

        public override async Task<IEnumerable<CartProduct>> Index()
        {
            return await base.Index();
        }

        public override async Task<CartProduct> Details(Guid id1, Guid id2)
        {
            return await base.Details(id1, id2);
        }

        public override async Task<CartProduct> Create(CartProduct relationship)
        {
            var cart = await Context.FindAsync<Cart>(relationship.Model1Id);
            if (cart == null) return null;
            cart.Total += relationship.ExtendedPrice;
            cart.Updated = DateTime.Now;

            return await base.Create(relationship);
        }

        public override async Task<List<CartProduct>> CreateRange(List<CartProduct> relationships)
        {
            return await base.CreateRange(relationships);
        }

        public override async Task Edit(CartProduct relationship)
        {
            var cartProduct = await Context.FindAsync<CartProduct>(relationship.Model1Id, relationship.Model2Id);
            var cart = await Context.FindAsync<Cart>(relationship.Model1Id);
            if (cartProduct != null && cart != null)
            {
                cart.Total -= cartProduct.ExtendedPrice;
                cart.Total += relationship.ExtendedPrice;
                cart.Updated = DateTime.Now;
                Context.Entry(cartProduct).State = EntityState.Detached;
                relationship.Updated = cart.Updated;
                Context.Entry(relationship).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
        }

        public override async Task EditRange(List<CartProduct> relationships)
        {
            await base.EditRange(relationships);
        }

        public override async Task Delete(Guid id1, Guid id2)
        {
            var cartProduct = await Context.FindAsync<CartProduct>(id1, id2);
            var cart = await Context.FindAsync<Cart>(id1);
            if (cartProduct != null && cart != null)
            {
                cart.Total -= cartProduct.ExtendedPrice;
                cart.Updated = DateTime.Now;
                Context.Remove(cartProduct);
                await Context.SaveChangesAsync();
            }
        }
    }
}
