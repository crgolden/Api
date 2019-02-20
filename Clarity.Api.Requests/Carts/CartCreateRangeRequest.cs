namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using Core;

    public class CartCreateRangeRequest : CreateRangeRequest<IEnumerable<Cart>, Cart>
    {
        public CartCreateRangeRequest(IEnumerable<Cart> carts) : base(carts)
        {
        }
    }
}
