namespace Clarity.Api
{
    using System;
    using Core;

    public class ProductFile : Entity
    {
        public string Name { get; set; }

        public string Uri { get; set; }

        public string ContentType { get; set; }

        public bool Primary { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public virtual Product Product { get; set; }

        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public virtual File File { get; set; }
    }
}
