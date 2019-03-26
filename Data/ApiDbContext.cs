namespace Clarity.Api
{
    using Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Shared;

    public class ApiDbContext : Context
    {
        private readonly IDemoFilesClient _demoFilesClient;
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        /// <inheritdoc />
        public ApiDbContext(
            DbContextOptions<ApiDbContext> options,
            IDemoFilesClient demoFilesClient,
            IOptions<DatabaseOptions> databaseOptions) : base(options)
        {
            _demoFilesClient = demoFilesClient;
            _databaseOptions = databaseOptions;
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new FileConfiguration(_demoFilesClient, _databaseOptions));
            modelBuilder.ApplyConfiguration(new OrderConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new PaymentConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new CartProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration(_databaseOptions));
            modelBuilder.ApplyConfiguration(new ProductFileConfiguration(_databaseOptions));
        }
    }
}
