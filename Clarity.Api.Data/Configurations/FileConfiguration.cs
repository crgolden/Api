namespace Clarity.Api.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> file)
        {
            file.Property(e => e.Created);
            file.Property(e => e.Updated);
            file.Property(e => e.Uri).IsRequired();
            file.Property(e => e.Name).IsRequired();
            file.Property(e => e.FileName).IsRequired();
            file.Property(e => e.ContentType);
            file.HasMany(e => e.ProductFiles).WithOne(e => e.File).HasForeignKey(e => e.FileId);
            file.ToTable("Files");
        }
    }
}
