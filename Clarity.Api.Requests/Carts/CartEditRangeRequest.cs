namespace Clarity.Api.Carts
{
    using System.Collections.Generic;
    using Core;

    public class CartEditRangeRequest : EditRangeRequest<Cart>
    {
        public CartEditRangeRequest(IEnumerable<Cart> carts) : base(carts)
        {
        }
    }
}
