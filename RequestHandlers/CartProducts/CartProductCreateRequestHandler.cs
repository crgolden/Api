﻿namespace crgolden.Api.CartProducts
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;

    public class CartProductCreateRequestHandler : CreateRequestHandler<CartProductCreateRequest, CartProduct, CartProductModel>
    {
        public CartProductCreateRequestHandler(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<(CartProductModel, object[])> Handle(CartProductCreateRequest request, CancellationToken token)
        {
            var cartProduct = Mapper.Map<CartProduct>(request.Model);
            Context.Add(cartProduct);
            await Context.SaveChangesAsync(token).ConfigureAwait(false);
            await Context.Entry(cartProduct).Reference(x => x.Product).LoadAsync(token).ConfigureAwait(false);
            return (Mapper.Map<CartProductModel>(cartProduct), new object[]{ cartProduct.CartId, cartProduct.ProductId });
        }
    }
}
