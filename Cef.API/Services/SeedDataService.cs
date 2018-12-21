namespace Cef.API.Services
{
    using System;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Faker;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SeedDataService : ISeedService
    {
        private readonly DbContext _context;
        private static Random Random => new Random();

        public SeedDataService(DbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Set<Product>().AnyAsync()) await SeedProducts();
        }

        private async Task SeedProducts()
        {
            for (var i = 0; i < 100; i++)
            {
                _context.Add(new Product
                {
                    Name = Name.First(),
                    Description = Lorem.Paragraph(),
                    Price = Random.Next(1, 1000)
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}