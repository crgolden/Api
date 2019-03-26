namespace Clarity.Api
{
    using System.Linq;
    using System.Threading;
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Options;
    using Shared;

    public class FileConfiguration : EntityConfiguration<File>
    {
        private readonly IDemoFilesClient _demoFilesClient;
        private readonly DatabaseOptions _options;

        public FileConfiguration(IDemoFilesClient demoFilesClient, IOptions<DatabaseOptions> options)
        {
            _demoFilesClient = demoFilesClient;
            _options = options.Value;
        }

        public override void Configure(EntityTypeBuilder<File> file)
        {
            base.Configure(file);
            file.HasMany(e => e.ProductFiles).WithOne(e => e.File).HasForeignKey(e => e.FileId);
            file.Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
            file.ToTable("Files");
            if (!_options.SeedData) return;
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var demoFileUrisAndSizes = _demoFilesClient
                    .GetDemoFileUrisAndSizes(cancellationTokenSource.Token)
                    .GetAwaiter()
                    .GetResult();
                file.HasData(SeedFiles.Files.Select((x, i) =>
                {
                    x.Uri = $"{demoFileUrisAndSizes[i].Item1}";
                    x.Size = demoFileUrisAndSizes[i].Item2;
                    return x;
                }));
            }
        }
    }
}
