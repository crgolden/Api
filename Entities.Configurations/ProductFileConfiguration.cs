namespace Clarity.Api
{
    using Abstractions;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class ProductFileConfiguration : EntityConfiguration<ProductFile>
    {
        private readonly DatabaseOptions _options;

        public ProductFileConfiguration(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<ProductFile> productFile)
        {
            base.Configure(productFile);
            productFile.HasKey(e => new { e.ProductId, e.FileId });
            productFile.HasOne(e => e.Product).WithMany(e => e.ProductFiles).HasForeignKey(e => e.ProductId);
            productFile.HasOne(e => e.File).WithMany(e => e.ProductFiles).HasForeignKey(e => e.FileId);
            productFile.ToTable("ProductFiles");
            if (!_options.SeedData) return;
            productFile.HasData(SeedProductFiles.ProductFiles);
        }
    }
}
