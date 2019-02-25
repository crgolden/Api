namespace Clarity.Api
{
    public static class SeedAddresses
    {
        public static object[] Addresses => new object[]
        {
            new
            {
                OrderId = SeedOrders.Orders[0].Id,
                StreetAddress = "6805 N CAPITAL OF TEXAS HWY STE 312",
                Locality = "AUSTIN",
                Region = "TX",
                PostalCode = "78731-1791",
                Country = "USA"
            },
            new
            {
                OrderId = SeedOrders.Orders[1].Id,
                StreetAddress = "6805 N CAPITAL OF TEXAS HWY STE 312",
                Locality = "AUSTIN",
                Region = "TX",
                PostalCode = "78731-1791",
                Country = "USA"
            },
            new
            {
                OrderId = SeedOrders.Orders[2].Id,
                StreetAddress = "6805 N CAPITAL OF TEXAS HWY STE 312",
                Locality = "AUSTIN",
                Region = "TX",
                PostalCode = "78731-1791",
                Country = "USA"
            },
            new
            {
                OrderId = SeedOrders.Orders[3].Id,
                StreetAddress = "6805 N CAPITAL OF TEXAS HWY STE 312",
                Locality = "AUSTIN",
                Region = "TX",
                PostalCode = "78731-1791",
                Country = "USA"
            },
            new
            {
                OrderId = SeedOrders.Orders[4].Id,
                StreetAddress = "6805 N CAPITAL OF TEXAS HWY STE 312",
                Locality = "AUSTIN",
                Region = "TX",
                PostalCode = "78731-1791",
                Country = "USA"
            }
        };
    }
}
