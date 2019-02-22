namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;

    public class File : Entity
    {
        public Guid Id { get; set; }

        public string Uri { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
    }
}