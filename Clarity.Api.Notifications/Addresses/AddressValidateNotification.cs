namespace Clarity.Api.Addresses
{
    using System;
    using Core;
    using MediatR;

    public class AddressValidateNotification : INotification
    {
        public EventIds EventId { get; set; }

        public Address Model { get; set; }

        public bool Valid { get; set; } = true;

        public Exception Exception { get; set; }
    }
}
