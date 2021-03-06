﻿namespace crgolden.Api
{
    using System;
    using Abstractions;
    using Core;

    public class OrderModel : Model
    {
        public Guid Id { get; set; }

        public string Number { get; set; }

        public Guid UserId { get; set; }

        public Address ShippingAddress { get; set; }

        public decimal? Shipping { get; set; }

        public decimal? Tax { get; set; }

        public decimal Total { get; set; }
    }
}
