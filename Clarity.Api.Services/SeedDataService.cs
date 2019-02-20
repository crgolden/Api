namespace Clarity.Api
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Bogus.DataSets;
    using Core;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    [ExcludeFromCodeCoverage]
    public class SeedDataService : ISeedService
    {
        private readonly DbContext _context;
        private readonly IStorageService _storageService;
        private readonly string _imagesContainer;
        private readonly string _thumbnailsContainer;
        private static Random Random => new Random();
        private static Lorem Lorem => new Lorem();

        public SeedDataService(
            DbContext context,
            IStorageService service,
            IOptions<StorageOptions> options)
        {
            _context = context;
            _storageService = service;
            _imagesContainer = options.Value.ImageContainer;
            _thumbnailsContainer = options.Value.ThumbnailContainer;
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
            await _storageService.DeleteAllFromStorageAsync();
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
                    var uri = await _storageService.UploadByteArrayToStorageAsync(
                        buffer: imageData,
                        fileName: fileName);
                    product.ProductFiles = new List<ProductFile>
                    {
                        new ProductFile
                        {
                            ContentType = "image/jpeg",
                            File = new File
                            {
                                Uri = $"{uri}",
                                ContentType = "image/jpeg",
                                FileName = fileName,
                                Name = imageName
                            },
                            FileName = imageName,
                            ProductName = product.Name,
                            Name = fileName,
                            Uri = $"{uri}",
                            Primary = true
                        },
                        new ProductFile
                        {
                            ContentType = "image/jpeg",
                            File = new File
                            {
                                Uri = $"{uri}".Replace(
                                    oldValue: $"{_imagesContainer}/",
                                    newValue: $"{_thumbnailsContainer}/"),
                                ContentType = "image/jpeg",
                                FileName = fileName,
                                Name = imageName
                            },
                            FileName = imageName,
                            ProductName = product.Name,
                            Name = fileName,
                            Uri = $"{uri}".Replace(
                                oldValue: $"{_imagesContainer}/",
                                newValue: $"{_thumbnailsContainer}/")
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
                var mockAddress = new Bogus.DataSets.Address();
                var address = new Core.Address
                {
                    StreetAddress = mockAddress.StreetAddress(),
                    Locality = mockAddress.City(),
                    Region = mockAddress.StateAbbr(),
                    PostalCode = mockAddress.ZipCode(),
                    Country = mockAddress.CountryCode()
                };
                var orderProductsCount = Random.Next(1, 10);
                var orderProducts = new OrderProduct[orderProductsCount];
                var products = await _context.Set<Product>()
                    .OrderBy(x => Guid.NewGuid())
                    .Take(orderProductsCount)
                    .ToArrayAsync();
                for (var j = 0; j < orderProductsCount; j++)
                {
                    var product = products[j];
                    orderProducts[j] = new OrderProduct
                    {
                        IsDownload = product.IsDownload,
                        Price = product.UnitPrice,
                        Quantity = Random.Next(1, 5),
                        OrderId = orderId,
                        Product = product,
                        ProductName = product.Name
                    };
                }

                var orderTotal = orderProducts.Sum(y => y.ExtendedPrice);
                var paymentsCount = Random.Next(1, 3);
                var payments = new Payment[paymentsCount];
                for (var j = 0; j < paymentsCount; j++)
                {
                    payments[j] = new Payment
                    {
                        Amount = orderTotal / payments.Length,
                        ChargeId = $"{Guid.NewGuid()}",
                        Currency = "USD",
                        CustomerCode = $"{Guid.NewGuid()}",
                        Description = $"Payment for {orderName}",
                        OrderId = orderId,
                        TokenId = $"{Guid.NewGuid()}",
                        UserId = userId
                    };
                }

                var order = new Order
                {
                    Id = orderId,
                    UserId = userId,
                    ShippingAddress = address,
                    Total = orderTotal,
                    OrderProducts = orderProducts,
                    Payments = payments
                };
                _context.Add(order);
            }

            await _context.SaveChangesAsync();
        }

        private static Category[] Categories() => new []
        {
            new Category
            {
                Name = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales"
            },
            new Category
            {
                Name = "Condiments",
                Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
            },
            new Category
            {
                Name = "Produce",
                Description = "Dried fruit and bean curd"
            },
            new Category
            {
                Name = "Meat/Poultry",
                Description = "Prepared meats"
            },
            new Category
            {
                Name = "Seafood",
                Description = "Seaweed and fish"
            },
            new Category
            {
                Name = "Dairy Products",
                Description = "Cheeses"
            },
            new Category
            {
                Name = "Confections",
                Description = "Desserts, candies, and sweet breads"
            },
            new Category
            {
                Name = "Grains/Cereals",
                Description = "Breads, crackers, pasta, and cereal"
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
                            ProductName = "Chai",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chang",
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
                            ProductName = "Chang",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Aniseed Syrup",
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
                            ProductName = "Aniseed Syrup",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chef Anton's Cajun Seasoning",
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
                            ProductName = "Chef Anton's Cajun Seasoning",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chef Anton's Gumbo Mix",
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
                            ProductName = "Chef Anton's Gumbo Mix",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Grandma's Boysenberry Spread",
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
                            ProductName = "Grandma's Boysenberry Spread",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Uncle Bob's Organic Dried Pears",
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
                            ProductName = "Uncle Bob's Organic Dried Pears",
                            Category = produce,
                            CategoryName = produce.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Northwoods Cranberry Sauce",
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
                            ProductName = "Northwoods Cranberry Sauce",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mishi Kobe Niku",
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
                            ProductName = "Mishi Kobe Niku",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ikura",
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
                            ProductName = "Ikura",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Queso Cabrales",
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
                            ProductName = "Queso Cabrales",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Queso Manchego La Pastora",
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
                            ProductName = "Queso Manchego La Pastora",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Konbu",
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
                            ProductName = "Konbu",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tofu",
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
                            ProductName = "Tofu",
                            Category = produce,
                            CategoryName = produce.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Genen Shouyu",
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
                            ProductName = "Genen Shouyu",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Pavlova",
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
                            ProductName = "Pavlova",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Alice Mutton",
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
                            ProductName = "Alice Mutton",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Carnarvon Tigers",
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
                            ProductName = "Carnarvon Tigers",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Teatime Chocolate Biscuits",
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
                            ProductName = "Teatime Chocolate Biscuits",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sir Rodney's Marmalade",
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
                            ProductName = "Sir Rodney's Marmalade",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sir Rodney's Scones",
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
                            ProductName = "Sir Rodney's Scones",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gustaf's Knäckebröd",
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
                            ProductName = "Gustaf's Knäckebröd",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tunnbröd",
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
                            ProductName = "Tunnbröd",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Guaraná Fantástica",
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
                            ProductName = "Guaraná Fantástica",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "NuNuCa Nuß-Nougat-Creme",
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
                            ProductName = "NuNuCa Nuß-Nougat-Creme",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gumbär Gummibärchen",
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
                            ProductName = "Gumbär Gummibärchen",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Schoggi Schokolade",
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
                            ProductName = "Schoggi Schokolade",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rössle Sauerkraut",
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
                            ProductName = "Rössle Sauerkraut",
                            Category = produce,
                            CategoryName = produce.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Thüringer Rostbratwurst",
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
                            ProductName = "Thüringer Rostbratwurst",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Nord-Ost Matjeshering",
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
                            ProductName = "Nord-Ost Matjeshering",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gorgonzola Telino",
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
                            ProductName = "Gorgonzola Telino",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mascarpone Fabioli",
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
                            ProductName = "Mascarpone Fabioli",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Geitost",
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
                            ProductName = "Geitost",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sasquatch Ale",
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
                            ProductName = "Sasquatch Ale",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Steeleye Stout",
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
                            ProductName = "Steeleye Stout",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Inlagd Sill",
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
                            ProductName = "Inlagd Sill",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gravad lax",
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
                            ProductName = "Gravad lax",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Côte de Blaye",
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
                            ProductName = "Côte de Blaye",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chartreuse verte",
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
                            ProductName = "Chartreuse verte",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Boston Crab Meat",
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
                            ProductName = "Boston Crab Meat",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Jack's New England Clam Chowder",
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
                            ProductName = "Jack's New England Clam Chowder",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Singaporean Hokkien Fried Mee",
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
                            ProductName = "Singaporean Hokkien Fried Mee",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ipoh Coffee",
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
                            ProductName = "Ipoh Coffee",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gula Malacca",
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
                            ProductName = "Gula Malacca",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rogede sild",
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
                            ProductName = "Rogede sild",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Spegesild",
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
                            ProductName = "Spegesild",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Zaanse koeken",
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
                            ProductName = "Zaanse koeken",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Chocolade",
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
                            ProductName = "Chocolade",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Maxilaku",
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
                            ProductName = "Maxilaku",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Valkoinen suklaa",
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
                            ProductName = "Valkoinen suklaa",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Manjimup Dried Apples",
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
                            ProductName = "Manjimup Dried Apples",
                            Category = produce,
                            CategoryName = produce.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Filo Mix",
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
                            ProductName = "Manjimup Dried Apples",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Perth Pasties",
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
                            ProductName = "Perth Pasties",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tourtière",
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
                            ProductName = "Tourtière",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Pâté chinois",
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
                            ProductName = "Pâté chinois",
                            Category = meatPoultry,
                            CategoryName = meatPoultry.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gnocchi di nonna Alice",
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
                            ProductName = "Gnocchi di nonna Alice",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Ravioli Angelo",
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
                            ProductName = "Ravioli Angelo",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Escargots de Bourgogne",
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
                            ProductName = "Escargots de Bourgogne",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Raclette Courdavault",
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
                            ProductName = "Raclette Courdavault",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Camembert Pierrot",
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
                            ProductName = "Camembert Pierrot",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Sirop d'érable",
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
                            ProductName = "Sirop d'érable",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Tarte au sucre",
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
                            ProductName = "Tarte au sucre",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Vegie-spread",
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
                            ProductName = "Vegie-spread",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Wimmers gute Semmelknödel",
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
                            ProductName = "Wimmers gute Semmelknödel",
                            Category = grainsCereals,
                            CategoryName = grainsCereals.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Louisiana Fiery Hot Pepper Sauce",
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
                            ProductName = "Louisiana Fiery Hot Pepper Sauce",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Louisiana Hot Spiced Okra",
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
                            ProductName = "Louisiana Hot Spiced Okra",
                            Category = condiments,
                            CategoryName = condiments.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Laughing Lumberjack Lager",
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
                            ProductName = "Laughing Lumberjack Lager",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Scottish Longbreads",
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
                            ProductName = "Scottish Longbreads",
                            Category = confections,
                            CategoryName = confections.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Gudbrandsdalsost",
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
                            ProductName = "Gudbrandsdalsost",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Outback Lager",
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
                            ProductName = "Outback Lager",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Flotemysost",
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
                            ProductName = "Flotemysost",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Mozzarella di Giovanni",
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
                            ProductName = "Mozzarella di Giovanni",
                            Category = dairyProducts,
                            CategoryName = dairyProducts.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Röd Kaviar",
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
                            ProductName = "Röd Kaviar",
                            Category = seafood,
                            CategoryName = seafood.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Longlife Tofu",
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
                            ProductName = "Longlife Tofu",
                            Category = produce,
                            CategoryName = produce.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Rhönbräu Klosterbier",
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
                            ProductName = "Rhönbräu Klosterbier",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                },
                new Product
                {
                    IsDownload = false,
                    Name = "Lakkalikööri",
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
                            ProductName = "Lakkalikööri",
                            Category = beverages,
                            CategoryName = beverages.Name
                        }
                    }
                }
            };
        }
    }
}
