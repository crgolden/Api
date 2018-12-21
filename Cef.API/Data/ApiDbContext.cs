namespace Cef.API.Data
{
    using Extensions;
    using Microsoft.EntityFrameworkCore;

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