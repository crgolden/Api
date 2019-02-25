namespace Clarity.Api
{
    using System;
    using Core;

    public class CartModel : Model
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }

        public decimal Total { get; set; }
    }
}
