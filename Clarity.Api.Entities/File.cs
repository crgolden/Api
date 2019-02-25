namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using Core;

    public class File : Entity
    {
        private readonly List<ProductFile> _productFiles;

        public Guid Id { get; private set; }

        public string Uri { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public virtual IReadOnlyCollection<ProductFile> ProductFiles => _productFiles;

        public File()
        {
            _productFiles = new List<ProductFile>();
        }

        public File(Guid id) : this()
        {
            Id = id;
        }

        public void AddProductFile(ProductFile productFile)
        {
            _productFiles.Add(productFile);
        }

        public bool RemoveProductFile(ProductFile productFile)
        {
            return _productFiles.Remove(productFile);
        }
    }
}