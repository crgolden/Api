namespace crgolden.Api
{
    using System;

    public static class SeedCategories
    {
        public static Category[] Categories => new []
        {
            // 00
            new Category(new Guid("8880372B-EC84-42E1-BCE7-941C2CF3DB34"))
            {
                Name = "Beverages",
                Description = "Soft drinks, coffees, teas, beers, and ales"
            },
            // 01
            new Category(new Guid("F6B8E946-172E-4063-BDCB-86EA0326F09D"))
            {
                Name = "Condiments",
                Description = "Sweet and savory sauces, relishes, spreads, and seasonings"
            },
            // 02
            new Category(new Guid("7030A699-7B00-4A85-AAD6-61AFEA983DF8"))
            {
                Name = "Produce",
                Description = "Dried fruit and bean curd"
            },
            // 03
            new Category(new Guid("BB71E15B-4112-4B7E-8154-4400034F0463"))
            {
                Name = "Meat/Poultry",
                Description = "Prepared meats"
            },
            // 04
            new Category(new Guid("585ADDAF-E033-4B4E-B461-4DEE169E0B47"))
            {
                Name = "Seafood",
                Description = "Seaweed and fish"
            },
            // 05
            new Category(new Guid("EC675684-09D8-4EE9-BF29-E2B561BB8A1B"))
            {
                Name = "Dairy Products",
                Description = "Cheeses"
            },
            // 06
            new Category(new Guid("C8A330D6-E2DC-457D-A3A2-445AACF70339"))
            {
                Name = "Confections",
                Description = "Desserts, candies, and sweet breads"
            },
            // 07
            new Category(new Guid("7FDC3396-A54C-400E-B6D8-1DF6958C89FD"))
            {
                Name = "Grains/Cereals",
                Description = "Breads, crackers, pasta, and cereal"
            }
        };
    }
}
