namespace Clarity.Api
{
    public static class SeedOrderProducts
    {
        public static OrderProduct[] OrderProducts => new []
        {
            // 00
            new OrderProduct(SeedOrders.Orders[0].Id, SeedProducts.Products[0].Id, 8),
            new OrderProduct(SeedOrders.Orders[0].Id, SeedProducts.Products[1].Id, 12),
            new OrderProduct(SeedOrders.Orders[0].Id, SeedProducts.Products[2].Id, 4),
            // 01
            new OrderProduct(SeedOrders.Orders[1].Id, SeedProducts.Products[3].Id, 6),
            new OrderProduct(SeedOrders.Orders[1].Id, SeedProducts.Products[4].Id, 20),
            new OrderProduct(SeedOrders.Orders[1].Id, SeedProducts.Products[5].Id, 16),
            // 02
            new OrderProduct(SeedOrders.Orders[2].Id, SeedProducts.Products[6].Id, 2),
            new OrderProduct(SeedOrders.Orders[2].Id, SeedProducts.Products[7].Id, 10),
            new OrderProduct(SeedOrders.Orders[2].Id, SeedProducts.Products[8].Id, 26),
            // 03
            new OrderProduct(SeedOrders.Orders[3].Id, SeedProducts.Products[9].Id, 48),
            new OrderProduct(SeedOrders.Orders[3].Id, SeedProducts.Products[10].Id, 2),
            new OrderProduct(SeedOrders.Orders[3].Id, SeedProducts.Products[11].Id, 18),
            // 04
            new OrderProduct(SeedOrders.Orders[4].Id, SeedProducts.Products[12].Id, 20),
            new OrderProduct(SeedOrders.Orders[4].Id, SeedProducts.Products[13].Id, 36),
            new OrderProduct(SeedOrders.Orders[4].Id, SeedProducts.Products[14].Id, 16)
        };
    }
}
