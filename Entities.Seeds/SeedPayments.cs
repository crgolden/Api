namespace Clarity.Api
{
    using System;

    public static class SeedPayments
    {
        public static Payment[] Payments => new []
        {
            new Payment(new Guid("BF1F6BE6-A662-49B7-B1FF-DF80D6328B1B"))
            {
                OrderId = SeedOrders.Orders[0].Id,
                UserId = SeedOrders.Orders[0].UserId,
                Amount = SeedProducts.Products[0].UnitPrice * 4 +
                         SeedProducts.Products[1].UnitPrice * 6 +
                         SeedProducts.Products[2].UnitPrice * 2,
                ChargeId = "7D327AC2-8F8A-406B-A8F5-F68148B0D065",
                Currency = "USD",
                CustomerCode = "097B52D8-34E6-4940-BD11-B7F7A0CC6D48",
                TokenId = "C7ED58F3-72EE-4D27-A143-CDCE2D966EE3"
            },
            new Payment(new Guid("BB33204D-4FC6-41BE-ADAF-371E39A589A6"))
            {
                OrderId = SeedOrders.Orders[0].Id,
                UserId = SeedOrders.Orders[0].UserId,
                Amount = SeedProducts.Products[0].UnitPrice * 4 +
                         SeedProducts.Products[1].UnitPrice * 6 +
                         SeedProducts.Products[2].UnitPrice * 2,
                ChargeId = "FC3F98C9-2A6E-4358-A467-B6AFAF1F2863",
                Currency = "USD",
                CustomerCode = "4877A522-EEEC-4E1C-8E9E-5B799BC179D2",
                TokenId = "0E67B8FE-FA89-4731-8853-8D05AA3544F2"
            },
            new Payment(new Guid("AD89C796-8C77-425C-8D83-0CD02CF930FD"))
            {
                OrderId = SeedOrders.Orders[1].Id,
                UserId = SeedOrders.Orders[1].UserId,
                Amount = SeedProducts.Products[3].UnitPrice * 3 +
                         SeedProducts.Products[4].UnitPrice * 10 +
                         SeedProducts.Products[5].UnitPrice * 8,
                ChargeId = "9E9C000B-F9FC-4192-9A38-80166B9CA9FB",
                Currency = "USD",
                CustomerCode = "7C2628DA-CF13-4055-BE71-1711191DA921",
                TokenId = "1CBC4524-EBF2-48F2-8271-756A380AA1AC"
            },
            new Payment(new Guid("9A50EE25-3D3C-4CFE-BA45-CC0FC9869E35"))
            {
                OrderId = SeedOrders.Orders[1].Id,
                UserId = SeedOrders.Orders[1].UserId,
                Amount = SeedProducts.Products[3].UnitPrice * 3 +
                         SeedProducts.Products[4].UnitPrice * 10 +
                         SeedProducts.Products[5].UnitPrice * 8,
                ChargeId = "076A81EB-5A44-4703-A6FA-D9056CF9F0A7",
                Currency = "USD",
                CustomerCode = "3AB09185-61E0-4A90-9745-EA2554B4B1F0",
                TokenId = "5EBA26DB-0D87-4F21-B525-8C80BEA5D6C5"
            },
            new Payment(new Guid("EC33F601-E37D-4025-84DC-1ABD348DA4E8"))
            {
                OrderId = SeedOrders.Orders[2].Id,
                UserId = SeedOrders.Orders[2].UserId,
                Amount = SeedProducts.Products[6].UnitPrice * 1 +
                         SeedProducts.Products[7].UnitPrice * 5 +
                         SeedProducts.Products[8].UnitPrice * 13,
                ChargeId = "F2BA9195-EECE-4C9F-9B7C-E6D568E428C0",
                Currency = "USD",
                CustomerCode = "B0922424-DAAA-4BD8-9EA3-77EA51AF0CDC",
                TokenId = "3B93FFB4-9B0D-46CF-A0F6-3B646E26B8FE"
            },
            new Payment(new Guid("9FFE2A32-CACB-4E8E-9BC1-B1EBE2B79F7F"))
            {
                OrderId = SeedOrders.Orders[2].Id,
                UserId = SeedOrders.Orders[2].UserId,
                Amount = SeedProducts.Products[6].UnitPrice * 1 +
                         SeedProducts.Products[7].UnitPrice * 5 +
                         SeedProducts.Products[8].UnitPrice * 13,
                ChargeId = "02CB9445-BD75-4FE3-A5C4-066C0C082E1A",
                Currency = "USD",
                CustomerCode = "EB1CB200-2EEB-4926-AFC2-5C52B4C8B84A",
                TokenId = "FE07E852-F778-460B-B7B7-CA15E344D632"
            },
            new Payment(new Guid("671E6F92-D37B-4491-9539-ED8D68C4C4EB"))
            {
                OrderId = SeedOrders.Orders[3].Id,
                UserId = SeedOrders.Orders[3].UserId,
                Amount = SeedProducts.Products[9].UnitPrice * 24 +
                         SeedProducts.Products[10].UnitPrice * 1 +
                         SeedProducts.Products[11].UnitPrice * 9,
                ChargeId = "25F2AA01-C5F0-4490-8ED9-6B4751E68630",
                Currency = "USD",
                CustomerCode = "7F4A4D1B-71C4-46FE-AE20-294747455DC5",
                TokenId = "7ECDF810-CB14-4143-938A-5AB9DC6E2A1C"
            },
            new Payment(new Guid("B10118D8-7C9D-48EF-9DFB-DD782246D937"))
            {
                OrderId = SeedOrders.Orders[3].Id,
                UserId = SeedOrders.Orders[3].UserId,
                Amount = SeedProducts.Products[9].UnitPrice * 24 +
                         SeedProducts.Products[10].UnitPrice * 1 +
                         SeedProducts.Products[11].UnitPrice * 9,
                ChargeId = "2806DC54-1EA1-443F-BCCF-3779C39BDBB5",
                Currency = "USD",
                CustomerCode = "7849EAB2-8A94-4216-A016-EA9851C98072",
                TokenId = "230E5B6A-AC4F-4907-AC25-242CE0CF9E42"
            },
            new Payment(new Guid("3E94D6B6-61EB-46AE-9B49-F0759F02B1A9"))
            {
                OrderId = SeedOrders.Orders[4].Id,
                UserId = SeedOrders.Orders[4].UserId,
                Amount = SeedProducts.Products[12].UnitPrice * 10 +
                         SeedProducts.Products[13].UnitPrice * 18 +
                         SeedProducts.Products[14].UnitPrice * 8,
                ChargeId = "89E0D67B-137F-49DD-A885-85C2DEBE5A1C",
                Currency = "USD",
                CustomerCode = "8CAFD586-740C-44CB-B238-BC23BB835782",
                TokenId = "7C7BC60B-3BF7-4B92-AD96-02AE97A1BF8C"
            },
            new Payment(new Guid("F9F1C58B-C77F-4C0F-BF70-4259F9F9386C"))
            {
                OrderId = SeedOrders.Orders[4].Id,
                UserId = SeedOrders.Orders[4].UserId,
                Amount = SeedProducts.Products[12].UnitPrice * 10 +
                         SeedProducts.Products[13].UnitPrice * 18 +
                         SeedProducts.Products[14].UnitPrice * 8,
                ChargeId = "DF2954AA-04AB-47D7-8E9F-17A7D55B6043",
                Currency = "USD",
                CustomerCode = "D8F88682-B3F6-4786-A7E0-327C9817A9E7",
                TokenId = "037A4FA3-C356-4AE2-A2F2-4FC4A9596886"
            }
        };
    }
}
