namespace crgolden.Api
{
    using System;

    public static class SeedOrders
    {
        public static Order[] Orders => new []
        {
            new Order(new Guid("6DADB928-E9ED-4115-A2DB-F0EFF0F4CF8F"))
            {
                UserId = new Guid("2CE77433-A490-4514-A8AE-344658D29D5F"),
                Total = SeedProducts.Products[0].UnitPrice * 8 +
                        SeedProducts.Products[1].UnitPrice * 12 +
                        SeedProducts.Products[2].UnitPrice * 4
            },
            new Order(new Guid("C81AC9BB-6F43-48DB-8E01-0986F9D697DE"))
            {
                UserId = new Guid("C3A3042A-5516-448A-8895-CE361B5D0AB8"),
                Total = SeedProducts.Products[3].UnitPrice * 6 +
                        SeedProducts.Products[4].UnitPrice * 20 +
                        SeedProducts.Products[5].UnitPrice * 16
            },
            new Order(new Guid("7193023B-BDBA-4C89-B568-A2F2F55E2C92"))
            {
                UserId = new Guid("8BC6860D-3EFE-4E27-B840-0C0706A07CA7"),
                Total = SeedProducts.Products[6].UnitPrice * 2 +
                        SeedProducts.Products[7].UnitPrice * 10 +
                        SeedProducts.Products[8].UnitPrice * 26
            },
            new Order(new Guid("91F088B7-C393-42E1-817D-AADF3DA1A892"))
            {
                UserId = new Guid("B34F9A23-51A8-46E7-9A2C-5930D9423AFB"),
                Total = SeedProducts.Products[9].UnitPrice * 48 +
                        SeedProducts.Products[10].UnitPrice * 2 +
                        SeedProducts.Products[11].UnitPrice * 18
            },
            new Order(new Guid("CCEAF62F-F10D-4039-980A-0E8EA09F17F4"))
            {
                UserId = new Guid("6DADB928-E9ED-4115-A2DB-F0EFF0F4CF8F"),
                Total = SeedProducts.Products[12].UnitPrice * 20 +
                        SeedProducts.Products[13].UnitPrice * 36 +
                        SeedProducts.Products[14].UnitPrice * 16
            }
        };
    }
}
