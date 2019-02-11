namespace Cef.API.Data
{
    using System.Diagnostics.CodeAnalysis;
    using Extensions;
    using Microsoft.EntityFrameworkCore;

    [ExcludeFromCodeCoverage]
    public class ApiDbContext : DbContext
    {
        /// <inheritdoc />
        /// <param name="options"></param>
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        /// <inheritdoc />
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureECommerceContext();
        }
    }
}