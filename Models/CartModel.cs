namespace crgolden.Api
{
    using System;
    using Abstractions;

    public class CartModel : Model
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }
    }
}
