namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductFileConfiguration : IEntityTypeConfiguration<ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductFile> productFile)
        {
            productFile.Property(e => e.Created);
            productFile.Property(e => e.Updated);
            productFile.HasKey(e => new { e.ProductId, e.FileId });
            productFile.Property(e => e.Uri).IsRequired();
            productFile.Property(e => e.ContentType);
            productFile.Property(e => e.Primary);
            productFile.Property(e => e.ProductName).IsRequired();
            productFile.Property(e => e.FileName).IsRequired();
            productFile.Property(e => e.Name).IsRequired();
            productFile.HasOne(e => e.Product).WithMany(e => e.ProductFiles).HasForeignKey(e => e.ProductId);
            productFile.HasOne(e => e.File).WithMany(e => e.ProductFiles).HasForeignKey(e => e.FileId);
            productFile.ToTable("ProductFiles");
        }
    }
}
