namespace crgolden.Api
{
    using System;
    using System.Collections.Generic;

    public class File : Core.File
    {
        private readonly List<ProductFile> _productFiles;

        public Guid Id { get; private set; }

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