namespace Cef.API.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Core.Interfaces;
    using Core.Utilities;
    using Bogus;
    using Bogus.DataSets;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Options;
    using Relationships;

    [ExcludeFromCodeCoverage]
    public class SeedDataService : ISeedService
    {
        private readonly DbContext _context;
        private readonly AzureBlobStorage _azureBlobStorage;
        private static Random Random => new Random();
        private static Lorem Lorem => new Lorem();
        private static DateTime Created => DateTime.UtcNow;

        public SeedDataService(DbContext context, IOptions<StorageOptions> options)
        {
            _context = context;
            _azureBlobStorage = options.Value.AzureBlobStorage;
        }

        public async Task SeedAsync()
        {
            if (!await _context.Set<Category>().AnyAsync()) await SeedCategories();
            if (!await _context.Set<Product>().AnyAsync()) await SeedProducts();
            if (!await _context.Set<Order>().AnyAsync()) await SeedOrders();
        }

        private async Task SeedCategories()
        {
            _context.Set<Category>().AddRange(Categories());
            await _context.SaveChangesAsync();
        }

        private async Task SeedProducts()
        {
            await AzureFilesUtility.DeleteAllFromStorageAsync(
                accountName: _azureBlobStorage.AccountName,
                accountKey: _azureBlobStorage.AccountKey,
                containerNames: new[]
                {
                    _azureBlobStorage.ImageContainer,
                    _azureBlobStorage.ThumbnailContainer
                });
            using (var client = new WebClient())
            {
                var products = await Products();
                for (var i = 0; i < products.Length; i++)
                {
                    var product = products[i];
                    var imageName = $"{i + 1}.jpg";
                    var imageUri = new Uri($"https://demos.telerik.com/kendo-ui/content/web/foods/{imageName}");
                    var imageData = await client.DownloadDataTaskAsync(imageUri);
                    var fileName = $"{Guid.NewGuid()}.jpg";
                    var uri = await AzureFilesUtility.UploadByteArrayToStorageAsync(
                        buffer: imageData,
                        fileName: fileName,
                        accountName: _azureBlobStorage.AccountName,
                        accountKey: _azureBlobStorage.AccountKey,
                        containerName: _azureBlobStorage.ImageContainer);
                    product.ProductFiles = new List<ProductFile>
                    {
                        new ProductFile
                        {
                            Created = Created,
                            ContentType = "image/jpeg",
                            Model1Name = product.Name,
                            Model2 = new File
                            {
                                Created = Created,
                                Uri = $"{uri}",
                                ContentType = "image/jpeg",
                                FileName = fileName,
                                Name = imageName
                            },
                            Model2Name = imageName,
                            Uri = $"{uri}",
                            Primary = true
                        },
                        new ProductFile
                        {
                            Created = Created,
                            ContentType = "image/jpeg",
                            Model1Name = product.Name,
                            Model2 = new File
                            {
                                Created = Created,
                                Uri = $"{uri}".Replace(
                                    oldValue: $"{_azureBlobStorage.ImageContainer}/",
                                    newValue: $"{_azureBlobStorage.ThumbnailContainer}/"),
                                ContentType = "image/jpeg",
                                FileName = fileName,
                                Name = imageName
                            },
                            Model2Name = imageName,
                            Uri = $"{uri}".Replace(
                                oldValue: $"{_azureBlobStorage.ImageContainer}/",
                                newValue: $"{_azureBlobStorage.ThumbnailContainer}/")
                        }
                    };
                }

                _context.Set<Product>().AddRange(products);
                await _context.SaveChangesAsync();
            }
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
                    .RuleFor(x => x.StreetAddress, mockAddress.StreetAddress())
                    .RuleFor(x => x.Locality, mockAddress.City())
                    .RuleFor(x => x.Region, mockAddress.State())
                    .RuleFor(x => x.PostalCode, mockAddress.ZipCode())
                    .RuleFor(x => x.Country, mockAddress.CountryCode())
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
                        .RuleFor(x => x.Created, created)
                        .RuleFor(x => x.Updated, (DateTime?) null)
                        .RuleFor(x => x.IsDownload, product.IsDownload)
                        .RuleFor(x => x.Price, product.UnitPrice)
                        .RuleFor(x => x.Quantity, Random.Next(1, 5))
                        .RuleFor(x => x.Model1, (Order) null)
                        .RuleFor(x => x.Model1Name, orderName)
                        .RuleFor(x => x.Model1Id, orderId)
                        .RuleFor(x => x.Model2, product)
                        .RuleFor(x => x.Model2Name, product.Name)
                        .RuleFor(x => x.Model2Id, product.Id)
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
                        .RuleFor(x => x.Id, Guid.NewGuid())
                        .RuleFor(x => x.Name, $"Payment {orderIndex}-{paymentIndex}")
                        .RuleFor(x => x.Amount, orderTotal / payments.Length)
                        .RuleFor(x => x.AuthorizationCode, (string) null)
                        .RuleFor(x => x.ChargeId, $"{Guid.NewGuid()}")
                        .RuleFor(x => x.Currency, "USD")
                        .RuleFor(x => x.Description, $"Payment for {orderName}")
                        .RuleFor(x => x.Order, (Order) null)
                        .RuleFor(x => x.OrderId, orderId)
                        .RuleFor(x => x.TokenId, $"{Guid.NewGuid()}")
                        .RuleFor(x => x.UserId, userId)
                        .RuleFor(x => x.Created, now.AddDays(Random.Next(0, daysDiff) * -1))
                        .RuleFor(x => x.Updated, (DateTime?) null)
                        .Generate();
                }

                var order = new Faker<Order>()
                    .StrictMode(true)
                    .RuleFor(x => x.Id, orderId)
                    .RuleFor(x => x.Name, orderName)
                    .RuleFor(x => x.UserId, userId)
                    .RuleFor(x => x.ShippingAddress, JsonConvert.SerializeObject(address, new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }))
                    .RuleFor(x => x.Total, orderTotal)
                    .RuleFor(x => x.OrderProducts, orderProducts)
                    .RuleFor(x => x.Payments, payments)
                    .RuleFor(x => x.Created, created)
                    .RuleFor(x => x.Updated, (DateTime?) null)
                    .Generate();
                _context.Add(order);
            }

            await _context.SaveChangesAsync();
        }

        private static Category[] Categories() => new []
        {
            new Category
            {
                Name = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales",
                Created= Created
            },
            new Category
            {
                Name = "Condiments",
                Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
                Created= Created
            },
            new Category
            {
                Name = "Produce",
                Description = "Dried fruit and bean curd",
                Created= Created
            },
            new Category
            {
                Name = "Meat/Poultry",
                Description = "Prepared meats",
                Created= Created
            },
            new Category
            {
                Name = "Seafood",
                Description = "Seaweed and fish",
                Created= Created
            },
            new Category
            {
                Name = "Dairy Products",
                Description = "Cheeses",
                Created= Created
            },
            new Category
            {
                Name = "Confections",
                Description = "Desserts, candies, and sweet breads",
                Created= Created
            },
            new Category
            {
                Name = "Grains/Cereals",
                Description = "Breads, crackers, pasta, and cereal",
                Created= Created
            }
        };

        private async Task<Product[]> Products()
        {
            var beverages = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Beverages"));
            var condiments = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Condiments"));
            var produce = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Produce"));
            var meatPoultry = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Meat/Poultry"));
            var seafood = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Seafood"));
            var dairyProducts = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Dairy Products"));
            var confections = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Confections"));
            var grainsCereals = await _context.Set<Category>().SingleAsync(x => x.Name.Equals("Grains/Cereals"));

            return new []
            {
                new Product
                {
                    IsDownload = false,
                    Name = "Chai",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 boxes x 20 bags",
                    UnitPrice = 18,
                    UnitsInStock = 39,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chai",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chang",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 12 oz bottles",
                    UnitPrice = 19,
                    UnitsInStock = 17,
                    UnitsOnOrder = 40,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chang",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Aniseed Syrup",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 550 ml bottles",
                    UnitPrice = 10,
                    UnitsInStock = 13,
                    UnitsOnOrder = 70,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Aniseed Syrup",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chef Anton's Cajun Seasoning",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "48 - 6 oz jars",
                    UnitPrice = 22,
                    UnitsInStock = 53,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chef Anton's Cajun Seasoning",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chef Anton's Gumbo Mix",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "36 boxes",
                    UnitPrice = 21.35m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chef Anton's Gumbo Mix",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Grandma's Boysenberry Spread",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 8 oz jars",
                    UnitPrice = 25,
                    UnitsInStock = 120,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Grandma's Boysenberry Spread",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Uncle Bob's Organic Dried Pears",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 1 lb pkgs.",
                    UnitPrice = 30,
                    UnitsInStock = 15,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Uncle Bob's Organic Dried Pears",
                            Model2 = produce,
                            Model2Name = produce.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Northwoods Cranberry Sauce",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 12 oz jars",
                    UnitPrice = 40,
                    UnitsInStock = 6,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Northwoods Cranberry Sauce",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mishi Kobe Niku",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "18 - 500 g pkgs.",
                    UnitPrice = 97,
                    UnitsInStock = 29,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Mishi Kobe Niku",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ikura",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 200 ml jars",
                    UnitPrice = 31,
                    UnitsInStock = 31,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Ikura",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Queso Cabrales",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "1 kg pkg.",
                    UnitPrice = 21,
                    UnitsInStock = 30,
                    UnitsOnOrder = 30,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Queso Cabrales",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Queso Manchego La Pastora",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 - 500 g pkgs.",
                    UnitPrice = 38,
                    UnitsInStock = 86,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Queso Manchego La Pastora",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Konbu",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "2 kg box",
                    UnitPrice = 6,
                    UnitsInStock = 24,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Konbu",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tofu",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "40 - 100 g pkgs.",
                    UnitPrice = 23.25m,
                    UnitsInStock = 35,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Tofu",
                            Model2 = produce,
                            Model2Name = produce.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Genen Shouyu",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 250 ml bottles",
                    UnitPrice = 15.5m,
                    UnitsInStock = 9,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Genen Shouyu",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Pavlova",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "32 - 500 g boxes",
                    UnitPrice = 17.45m,
                    UnitsInStock = 29,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Pavlova",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Alice Mutton",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "20 - 1 kg tins",
                    UnitPrice = 39,
                    UnitsInStock = 0,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Alice Mutton",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Carnarvon Tigers",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "16 kg pkg.",
                    UnitPrice = 62.5m,
                    UnitsInStock = 42,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Carnarvon Tigers",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Teatime Chocolate Biscuits",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 boxes x 12 pieces",
                    UnitPrice = 9.2m,
                    UnitsInStock = 25,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Teatime Chocolate Biscuits",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sir Rodney's Marmalade",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "30 gift boxes",
                    UnitPrice = 81,
                    UnitsInStock = 40,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Sir Rodney's Marmalade",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sir Rodney's Scones",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 pkgs. x 4 pieces",
                    UnitPrice = 10,
                    UnitsInStock = 3,
                    UnitsOnOrder = 40,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Sir Rodney's Scones",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gustaf's Knäckebröd",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 500 g pkgs.",
                    UnitPrice = 21,
                    UnitsInStock = 104,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gustaf's Knäckebröd",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tunnbröd",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 250 g pkgs.",
                    UnitPrice = 9,
                    UnitsInStock = 61,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Tunnbröd",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Guaraná Fantástica",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 355 ml cans",
                    UnitPrice = 4.5m,
                    UnitsInStock = 20,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Guaraná Fantástica",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "NuNuCa Nuß-Nougat-Creme",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "20 - 450 g glasses",
                    UnitPrice = 14,
                    UnitsInStock = 76,
                    UnitsOnOrder = 0,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "NuNuCa Nuß-Nougat-Creme",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gumbär Gummibärchen",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "100 - 250 g bags",
                    UnitPrice = 31.23m,
                    UnitsInStock = 15,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gumbär Gummibärchen",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Schoggi Schokolade",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "100 - 100 g pieces",
                    UnitPrice = 43.9m,
                    UnitsInStock = 49,
                    UnitsOnOrder = 0,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Schoggi Schokolade",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rössle Sauerkraut",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "25 - 825 g cans",
                    UnitPrice = 45.6m,
                    UnitsInStock = 26,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Rössle Sauerkraut",
                            Model2 = produce,
                            Model2Name = produce.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Thüringer Rostbratwurst",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "50 bags x 30 sausgs.",
                    UnitPrice = 123.79m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Thüringer Rostbratwurst",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Nord-Ost Matjeshering",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 - 200 g glasses",
                    UnitPrice = 25.89m,
                    UnitsInStock = 10,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Nord-Ost Matjeshering",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gorgonzola Telino",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 100 g pkgs",
                    UnitPrice = 12.5m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 70,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gorgonzola Telino",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mascarpone Fabioli",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 200 g pkgs.",
                    UnitPrice = 32,
                    UnitsInStock = 9,
                    UnitsOnOrder = 40,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Mascarpone Fabioli",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Geitost",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "500 g",
                    UnitPrice = 2.5m,
                    UnitsInStock = 112,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Geitost",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sasquatch Ale",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 12 oz bottles",
                    UnitPrice = 14,
                    UnitsInStock = 111,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Sasquatch Ale",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Steeleye Stout",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 12 oz bottles",
                    UnitPrice = 18,
                    UnitsInStock = 20,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Steeleye Stout",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Inlagd Sill",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 250 g  jars",
                    UnitPrice = 19,
                    UnitsInStock = 112,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Inlagd Sill",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gravad lax",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 500 g pkgs.",
                    UnitPrice = 26,
                    UnitsInStock = 11,
                    UnitsOnOrder = 50,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gravad lax",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Côte de Blaye",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 75 cl bottles",
                    UnitPrice = 263.5m,
                    UnitsInStock = 17,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Côte de Blaye",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chartreuse verte",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "750 cc per bottle",
                    UnitPrice = 18,
                    UnitsInStock = 69,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chartreuse verte",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Boston Crab Meat",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 4 oz tins",
                    UnitPrice = 18.4m,
                    UnitsInStock = 123,
                    UnitsOnOrder = 0,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Boston Crab Meat",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Jack's New England Clam Chowder",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 12 oz cans",
                    UnitPrice = 9.65m,
                    UnitsInStock = 85,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Jack's New England Clam Chowder",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Singaporean Hokkien Fried Mee",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "32 - 1 kg pkgs.",
                    UnitPrice = 14,
                    UnitsInStock = 26,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Singaporean Hokkien Fried Mee",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ipoh Coffee",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "16 - 500 g tins",
                    UnitPrice = 46,
                    UnitsInStock = 17,
                    UnitsOnOrder = 10,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Ipoh Coffee",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gula Malacca",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "20 - 2 kg bags",
                    UnitPrice = 19.45m,
                    UnitsInStock = 27,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gula Malacca",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rogede sild",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "1k pkg.",
                    UnitPrice = 9.5m,
                    UnitsInStock = 5,
                    UnitsOnOrder = 70,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Rogede sild",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Spegesild",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "4 - 450 g glasses",
                    UnitPrice = 12,
                    UnitsInStock = 95,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Spegesild",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Zaanse koeken",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 - 4 oz boxes",
                    UnitPrice = 9.5m,
                    UnitsInStock = 36,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Zaanse koeken",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chocolade",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 pkgs.",
                    UnitPrice = 12.75m,
                    UnitsInStock = 15,
                    UnitsOnOrder = 70,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Chocolade",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Maxilaku",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 50 g pkgs.",
                    UnitPrice = 20,
                    UnitsInStock = 10,
                    UnitsOnOrder = 60,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Maxilaku",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Valkoinen suklaa",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "12 - 100 g bars",
                    UnitPrice = 16.25m,
                    UnitsInStock = 65,
                    UnitsOnOrder = 0,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Valkoinen suklaa",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Manjimup Dried Apples",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "50 - 300 g pkgs.",
                    UnitPrice = 53,
                    UnitsInStock = 20,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Manjimup Dried Apples",
                            Model2 = produce,
                            Model2Name = produce.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Filo Mix",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "16 - 2 kg boxes",
                    UnitPrice = 7,
                    UnitsInStock = 38,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Manjimup Dried Apples",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Perth Pasties",
                    Created = Created,
                    Active = false,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "48 pieces",
                    UnitPrice = 32.8m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Perth Pasties",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tourtière",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "16 pies",
                    UnitPrice = 7.458m,
                    UnitsInStock = 21,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Tourtière",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Pâté chinois",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 boxes x 2 pies",
                    UnitPrice = 24,
                    UnitsInStock = 115,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Pâté chinois",
                            Model2 = meatPoultry,
                            Model2Name = meatPoultry.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gnocchi di nonna Alice",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 250 g pkgs.",
                    UnitPrice = 38,
                    UnitsInStock = 21,
                    UnitsOnOrder = 10,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gnocchi di nonna Alice",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ravioli Angelo",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 250 g pkgs.",
                    UnitPrice = 19.5m,
                    UnitsInStock = 36,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Ravioli Angelo",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Escargots de Bourgogne",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 pieces",
                    UnitPrice = 13.25m,
                    UnitsInStock = 62,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Escargots de Bourgogne",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Raclette Courdavault",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "5 kg pkg.",
                    UnitPrice = 55,
                    UnitsInStock = 79,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Raclette Courdavault",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Camembert Pierrot",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "15 - 300 g rounds",
                    UnitPrice = 34,
                    UnitsInStock = 19,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Camembert Pierrot",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sirop d'érable",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 500 ml bottles",
                    UnitPrice = 28.5m,
                    UnitsInStock = 113,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Sirop d'érable",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tarte au sucre",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "48 pies",
                    UnitPrice = 49.3m,
                    UnitsInStock = 17,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Tarte au sucre",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Vegie-spread",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "15 - 625 g jars",
                    UnitPrice = 43.9m,
                    UnitsInStock = 24,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Vegie-spread",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Wimmers gute Semmelknödel",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "20 bags x 4 pieces",
                    UnitPrice = 33.25m,
                    UnitsInStock = 22,
                    UnitsOnOrder = 80,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Wimmers gute Semmelknödel",
                            Model2 = grainsCereals,
                            Model2Name = grainsCereals.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Louisiana Fiery Hot Pepper Sauce",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "32 - 8 oz bottles",
                    UnitPrice = 21.05m,
                    UnitsInStock = 76,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Louisiana Fiery Hot Pepper Sauce",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Louisiana Hot Spiced Okra",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 8 oz jars",
                    UnitPrice = 17,
                    UnitsInStock = 4,
                    UnitsOnOrder = 100,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Louisiana Hot Spiced Okra",
                            Model2 = condiments,
                            Model2Name = condiments.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Laughing Lumberjack Lager",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 12 oz bottles",
                    UnitPrice = 14,
                    UnitsInStock = 52,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Laughing Lumberjack Lager",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Scottish Longbreads",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 boxes x 8 pieces",
                    UnitPrice = 12.5m,
                    UnitsInStock = 6,
                    UnitsOnOrder = 10,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Scottish Longbreads",
                            Model2 = confections,
                            Model2Name = confections.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gudbrandsdalsost",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 kg pkg.",
                    UnitPrice = 36,
                    UnitsInStock = 26,
                    UnitsOnOrder = 0,
                    ReorderLevel = 15,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Gudbrandsdalsost",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Outback Lager",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 355 ml bottles",
                    UnitPrice = 15,
                    UnitsInStock = 15,
                    UnitsOnOrder = 10,
                    ReorderLevel = 30,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Outback Lager",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Flotemysost",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "10 - 500 g pkgs.",
                    UnitPrice = 21.5m,
                    UnitsInStock = 26,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Flotemysost",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mozzarella di Giovanni",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 200 g pkgs.",
                    UnitPrice = 34.8m,
                    UnitsInStock = 14,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Mozzarella di Giovanni",
                            Model2 = dairyProducts,
                            Model2Name = dairyProducts.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Röd Kaviar",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 150 g jars",
                    UnitPrice = 15,
                    UnitsInStock = 101,
                    UnitsOnOrder = 0,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Röd Kaviar",
                            Model2 = seafood,
                            Model2Name = seafood.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Longlife Tofu",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "5 kg pkg.",
                    UnitPrice = 10,
                    UnitsInStock = 4,
                    UnitsOnOrder = 20,
                    ReorderLevel = 5,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Longlife Tofu",
                            Model2 = produce,
                            Model2Name = produce.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rhönbräu Klosterbier",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "24 - 0.5 l bottles",
                    UnitPrice = 7.75m,
                    UnitsInStock = 125,
                    UnitsOnOrder = 0,
                    ReorderLevel = 25,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Rhönbräu Klosterbier",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Lakkalikööri",
                    Created = Created,
                    Active = true,
                    Description = Lorem.Sentence(),
                    QuantityPerUnit = "500 ml",
                    UnitPrice = 18,
                    UnitsInStock = 57,
                    UnitsOnOrder = 0,
                    ReorderLevel = 20,
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory
                        {
                            Model1Name = "Lakkalikööri",
                            Model2 = beverages,
                            Model2Name = beverages.Name,
                            Created = Created
                        }
                    }
                }
            };
        }
    }
}
