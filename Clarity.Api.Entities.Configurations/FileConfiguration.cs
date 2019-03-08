namespace Clarity.Api
{
    using System.Linq;
    using System.Threading;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;

    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        private readonly IDemoFilesClient _demoFilesClient;
        private readonly DatabaseOptions _options;

        public FileConfiguration(IDemoFilesClient demoFilesClient, IOptions<DatabaseOptions> options)
        {
            _demoFilesClient = demoFilesClient;
            _options = options.Value;
        }

        public void Configure(EntityTypeBuilder<File> file)
        {
            file.Property(e => e.Created).HasDefaultValueSql("getutcdate()");
            file.Property(e => e.Updated);
            file.Property(e => e.Uri).IsRequired();
            file.HasIndex(e => e.Uri).IsUnique();
            file.Property(e => e.Name).IsRequired();
            file.Property(e => e.ContentType);
            file.HasMany(e => e.ProductFiles).WithOne(e => e.File).HasForeignKey(e => e.FileId);
            file.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            file.ToTable("Files");
            if (!_options.SeedData) return;
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var demoFileUris = _demoFilesClient
                    .GetDemoFileUris(cancellationTokenSource.Token)
                    .GetAwaiter()
                    .GetResult();
                file.HasData(SeedFiles.Files.Select((x, i) =>
                {
                    x.Uri = $"{demoFileUris[i]}";
                    return x;
                }));
            }
        }
    }
}
