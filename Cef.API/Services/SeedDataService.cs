namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Bogus;
    using Bogus.DataSets;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Newtonsoft.Json;
    using Relationships;

    public class SeedDataService : ISeedService
    {
        private readonly DbContext _context;
        private static Random Random => new Random();
        private static Lorem Lorem => new Lorem();

        public SeedDataService(DbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Set<Product>().AnyAsync()) await SeedProducts();
            if (!await _context.Set<Order>().AnyAsync()) await SeedOrders();
        }

        private async Task SeedProducts()
        {
            var product = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Random.Word())
                .RuleFor(x => x.Active, f => f.Random.Bool())
                .RuleFor(x => x.Created, f => DateTime.Now)
                .RuleFor(x => x.Updated, f => null)
                .RuleFor(x => x.Price, f => Random.Next(0, 100))
                .RuleFor(x => x.Description, Lorem.Sentences(3))
                .RuleFor(x => x.CartProducts, f => new List<CartProduct>())
                .RuleFor(x => x.IsDownload, f => f.Random.Bool())
                .RuleFor(x => x.OrderProducts, f => new List<OrderProduct>())
                .RuleFor(x => x.ProductFiles, f => new List<ProductFile>());
            _context.AddRange(product.Generate(100));
            await _context.SaveChangesAsync();
        }

        private async Task SeedOrders()
        {
            for (var i = 0; i < 100; i++)
            {
                var orderIndex = i + 1;
                var orderId = Guid.NewGuid();
                var orderName = $"Order {orderIndex}";
                var userId = Guid.NewGuid();
                var created = DateTime.Now.AddDays(Random.Next(1, 100) * -1);
                var mockAddress = new Address();
                var address = new Faker<AddressClaim>()
                    .StrictMode(true)
                    .RuleFor(x => x.StreetAddress, f => mockAddress.StreetAddress())
                    .RuleFor(x => x.Locality, f => mockAddress.City())
                    .RuleFor(x => x.Region, f => mockAddress.State())
                    .RuleFor(x => x.PostalCode, f => mockAddress.ZipCode())
                    .RuleFor(x => x.Country, f => mockAddress.CountryCode())
                    .Generate();
                var orderProductsCount = Random.Next(1, 10);
                var orderProducts = new OrderProduct[orderProductsCount];
                var products = await _context.Set<Product>()
                    .OrderBy(x => Guid.NewGuid())
                    .Take(orderProductsCount)
                    .ToArrayAsync();
                for (var j = 0; j < orderProductsCount; j++)
                {
                    var product = products[j];
                    orderProducts[j] = new Faker<OrderProduct>()
                        .StrictMode(true)
                        .RuleFor(x => x.Created, f => created)
                        .RuleFor(x => x.Updated, f => null)
                        .RuleFor(x => x.IsDownload, f => product.IsDownload)
                        .RuleFor(x => x.Price, f => product.Price)
                        .RuleFor(x => x.Quantity, f => Random.Next(1, 5))
                        .RuleFor(x => x.Model1, f => null)
                        .RuleFor(x => x.Model1Name, f => orderName)
                        .RuleFor(x => x.Model1Id, f => orderId)
                        .RuleFor(x => x.Model2, f => product)
                        .RuleFor(x => x.Model2Name, f => product.Name)
                        .RuleFor(x => x.Model2Id, f => product.Id)
                        .Generate();
                }

                var orderTotal = orderProducts.Sum(y => y.ExtendedPrice);
                var paymentsCount = Random.Next(1, 3);
                var payments = new Payment[paymentsCount];
                for (var j = 0; j < paymentsCount; j++)
                {
                    var createdDay = created.Day;
                    var now = DateTime.Now;
                    var nowDay = now.Day;
                    var daysDiff = Math.Abs(nowDay - createdDay);
                    var paymentIndex = j + 1;
                    payments[j] = new Faker<Payment>()
                        .StrictMode(true)
                        .RuleFor(x => x.Id, f => Guid.NewGuid())
                        .RuleFor(x => x.Name, f => $"Payment {orderIndex}-{paymentIndex}")
                        .RuleFor(x => x.Amount, f => orderTotal / payments.Length)
                        .RuleFor(x => x.AuthorizationCode, f => null)
                        .RuleFor(x => x.ChargeId, f => $"{Guid.NewGuid()}")
                        .RuleFor(x => x.Currency, f => "USD")
                        .RuleFor(x => x.Description, f => $"Payment for {orderName}")
                        .RuleFor(x => x.Order, f => null)
                        .RuleFor(x => x.OrderId, f => orderId)
                        .RuleFor(x => x.TokenId, f => $"{Guid.NewGuid()}")
                        .RuleFor(x => x.UserId, f => userId)
                        .RuleFor(x => x.Created, f => now.AddDays(Random.Next(0, daysDiff) * -1))
                        .RuleFor(x => x.Updated, f => null)
                        .Generate();
                }

                var order = new Faker<Order>()
                    .StrictMode(true)
                    .RuleFor(x => x.Id, f => orderId)
                    .RuleFor(x => x.Name, f => orderName)
                    .RuleFor(x => x.UserId, f => userId)
                    .RuleFor(x => x.ShippingAddress, f => JsonConvert.SerializeObject(address))
                    .RuleFor(x => x.Total, f => orderTotal)
                    .RuleFor(x => x.OrderProducts, f => orderProducts)
                    .RuleFor(x => x.Payments, f => payments)
                    .RuleFor(x => x.Created, f => created)
                    .RuleFor(x => x.Updated, f => null)
                    .Generate();
                _context.Add(order);
            }

            await _context.SaveChangesAsync();
        }
    }
}