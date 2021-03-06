﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace crgolden.Api.Migrations
{
    public partial class ProductCartOrderPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ShippingStreet = table.Column<string>(nullable: true),
                    ShippingCity = table.Column<string>(nullable: true),
                    ShippingState = table.Column<string>(nullable: true),
                    ShippingZipCode = table.Column<string>(nullable: true),
                    ShippingCountry = table.Column<string>(nullable: true),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDownload = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    QuantityPerUnit = table.Column<string>(nullable: false),
                    ReorderLevel = table.Column<int>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    UnitsInStock = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsOnOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ChargeId = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TokenId = table.Column<string>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProducts",
                columns: table => new
                {
                    CartId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CartProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFiles",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFiles", x => new { x.ProductId, x.FileId });
                    table.ForeignKey(
                        name: "FK_ProductFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(2574), "Soft drinks, coffees, teas, beers, and ales", "Beverages", null },
                    { new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4026), "Sweet and savory sauces, relishes, spreads, and seasonings", "Condiments", null },
                    { new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4044), "Dried fruit and bean curd", "Produce", null },
                    { new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4050), "Prepared meats", "Meat/Poultry", null },
                    { new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4056), "Seaweed and fish", "Seafood", null },
                    { new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4063), "Cheeses", "Dairy Products", null },
                    { new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4069), "Desserts, candies, and sweet breads", "Confections", null },
                    { new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 13, 602, DateTimeKind.Utc).AddTicks(4075), "Breads, crackers, pasta, and cereal", "Grains/Cereals", null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "ContentType", "Created", "Extension", "Name", "Size", "Updated", "Uri" },
                values: new object[,]
                {
                    { new Guid("8703e152-aeaa-43f4-b607-3b803f6ab773"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6763), ".jpg", "8703E152-AEAA-43F4-B607-3B803F6AB773.jpg", 18102L, null, "https://crgoldenblob.blob.core.windows.net/images/8703e152-aeaa-43f4-b607-3b803f6ab773.jpg" },
                    { new Guid("c68ebcdd-7cc3-45a0-b088-29dc950dae60"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6757), ".jpg", "C68EBCDD-7CC3-45A0-B088-29DC950DAE60.jpg", 20540L, null, "https://crgoldenblob.blob.core.windows.net/images/c68ebcdd-7cc3-45a0-b088-29dc950dae60.jpg" },
                    { new Guid("a8189d9d-7185-4c2c-bf48-f0cc797a2acc"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6751), ".jpg", "A8189D9D-7185-4C2C-BF48-F0CC797A2ACC.jpg", 18102L, null, "https://crgoldenblob.blob.core.windows.net/images/a8189d9d-7185-4c2c-bf48-f0cc797a2acc.jpg" },
                    { new Guid("c9cc388f-6645-4c31-b19c-f566ee06c0dc"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6735), ".jpg", "C9CC388F-6645-4C31-B19C-F566EE06C0DC.jpg", 20196L, null, "https://crgoldenblob.blob.core.windows.net/images/c9cc388f-6645-4c31-b19c-f566ee06c0dc.jpg" },
                    { new Guid("771cd746-df18-4b3d-b7a3-68d426fe7bb9"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6729), ".jpg", "771CD746-DF18-4B3D-B7A3-68D426FE7BB9.jpg", 17618L, null, "https://crgoldenblob.blob.core.windows.net/images/771cd746-df18-4b3d-b7a3-68d426fe7bb9.jpg" },
                    { new Guid("e0403ce3-cf8d-48d3-8a21-0af39c40ddee"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6723), ".jpg", "E0403CE3-CF8D-48D3-8A21-0AF39C40DDEE.jpg", 14389L, null, "https://crgoldenblob.blob.core.windows.net/images/e0403ce3-cf8d-48d3-8a21-0af39c40ddee.jpg" },
                    { new Guid("b589c46f-9572-4088-ba25-a5f67364b2ec"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6717), ".jpg", "B589C46F-9572-4088-BA25-A5F67364B2EC.jpg", 21196L, null, "https://crgoldenblob.blob.core.windows.net/images/b589c46f-9572-4088-ba25-a5f67364b2ec.jpg" },
                    { new Guid("968a4281-a54e-4397-8304-5ad1c471590e"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6694), ".jpg", "968A4281-A54E-4397-8304-5AD1C471590E.jpg", 21502L, null, "https://crgoldenblob.blob.core.windows.net/images/968a4281-a54e-4397-8304-5ad1c471590e.jpg" },
                    { new Guid("12b70183-6634-419f-9fe8-4e9982bf84c4"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6706), ".jpg", "12B70183-6634-419F-9FE8-4E9982BF84C4.jpg", 22345L, null, "https://crgoldenblob.blob.core.windows.net/images/12b70183-6634-419f-9fe8-4e9982bf84c4.jpg" },
                    { new Guid("1fa60ef2-2d80-468e-88ed-f1ba3c8bfe96"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6700), ".jpg", "1FA60EF2-2D80-468E-88ED-F1BA3C8BFE96.jpg", 20073L, null, "https://crgoldenblob.blob.core.windows.net/images/1fa60ef2-2d80-468e-88ed-f1ba3c8bfe96.jpg" },
                    { new Guid("212c48d4-38ef-42b3-951b-2a7dda0a0746"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6769), ".jpg", "212C48D4-38EF-42B3-951B-2A7DDA0A0746.jpg", 19226L, null, "https://crgoldenblob.blob.core.windows.net/images/212c48d4-38ef-42b3-951b-2a7dda0a0746.jpg" },
                    { new Guid("c9d92c74-07be-4ab4-9e8e-6293bfb4c530"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6689), ".jpg", "C9D92C74-07BE-4AB4-9E8E-6293BFB4C530.jpg", 17246L, null, "https://crgoldenblob.blob.core.windows.net/images/c9d92c74-07be-4ab4-9e8e-6293bfb4c530.jpg" },
                    { new Guid("1a6ef266-ab6f-4a01-966f-a19f26486bc8"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6683), ".jpg", "1A6EF266-AB6F-4A01-966F-A19F26486BC8.jpg", 15912L, null, "https://crgoldenblob.blob.core.windows.net/images/1a6ef266-ab6f-4a01-966f-a19f26486bc8.jpg" },
                    { new Guid("ef8eb060-d1a6-4b66-a4ca-638977527a15"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6677), ".jpg", "EF8EB060-D1A6-4B66-A4CA-638977527A15.jpg", 24298L, null, "https://crgoldenblob.blob.core.windows.net/images/ef8eb060-d1a6-4b66-a4ca-638977527a15.jpg" },
                    { new Guid("0dcaf98a-fd3e-4112-9fda-3fa7da1ad290"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6671), ".jpg", "0DCAF98A-FD3E-4112-9FDA-3FA7DA1AD290.jpg", 19658L, null, "https://crgoldenblob.blob.core.windows.net/images/0dcaf98a-fd3e-4112-9fda-3fa7da1ad290.jpg" },
                    { new Guid("1eb79abb-84bc-41c8-9978-92cae1f2b6d2"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6712), ".jpg", "1EB79ABB-84BC-41C8-9978-92CAE1F2B6D2.jpg", 15860L, null, "https://crgoldenblob.blob.core.windows.net/images/1eb79abb-84bc-41c8-9978-92cae1f2b6d2.jpg" },
                    { new Guid("d28c4f4f-6048-4a93-a47a-d7db0c81a27a"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6775), ".jpg", "D28C4F4F-6048-4A93-A47A-D7DB0C81A27A.jpg", 19271L, null, "https://crgoldenblob.blob.core.windows.net/images/d28c4f4f-6048-4a93-a47a-d7db0c81a27a.jpg" },
                    { new Guid("8d12d30e-899e-4533-8faa-11716affdefe"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6797), ".jpg", "8D12D30E-899E-4533-8FAA-11716AFFDEFE.jpg", 17837L, null, "https://crgoldenblob.blob.core.windows.net/images/8d12d30e-899e-4533-8faa-11716affdefe.jpg" },
                    { new Guid("4f71a1f9-bf6f-4653-ae85-a6dad07b80e6"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6786), ".jpg", "4F71A1F9-BF6F-4653-AE85-A6DAD07B80E6.jpg", 21109L, null, "https://crgoldenblob.blob.core.windows.net/images/4f71a1f9-bf6f-4653-ae85-a6dad07b80e6.jpg" },
                    { new Guid("1fc5ad0e-91cf-4fcd-afcc-73a51bd94905"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6880), ".jpg", "1FC5AD0E-91CF-4FCD-AFCC-73A51BD94905.jpg", 11258L, null, "https://crgoldenblob.blob.core.windows.net/images/1fc5ad0e-91cf-4fcd-afcc-73a51bd94905.jpg" },
                    { new Guid("183f872c-1a26-4f44-ac02-63cba826ff59"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6869), ".jpg", "183F872C-1A26-4F44-AC02-63CBA826FF59.jpg", 25734L, null, "https://crgoldenblob.blob.core.windows.net/images/183f872c-1a26-4f44-ac02-63cba826ff59.jpg" },
                    { new Guid("681ffa4f-6d3b-460c-be10-a8376eb7bb15"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6864), ".jpg", "681FFA4F-6D3B-460C-BE10-A8376EB7BB15.jpg", 21218L, null, "https://crgoldenblob.blob.core.windows.net/images/681ffa4f-6d3b-460c-be10-a8376eb7bb15.jpg" },
                    { new Guid("80d595ef-d82c-4c55-a4bd-60b29d4953e9"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6859), ".jpg", "80D595EF-D82C-4C55-A4BD-60B29D4953E9.jpg", 16521L, null, "https://crgoldenblob.blob.core.windows.net/images/80d595ef-d82c-4c55-a4bd-60b29d4953e9.jpg" },
                    { new Guid("b4ecc589-9e7f-4d00-bc93-4d87e97441fb"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6853), ".jpg", "B4ECC589-9E7F-4D00-BC93-4D87E97441FB.jpg", 13658L, null, "https://crgoldenblob.blob.core.windows.net/images/b4ecc589-9e7f-4d00-bc93-4d87e97441fb.jpg" },
                    { new Guid("9769498b-8cae-4e37-863b-379e77cfef1e"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6847), ".jpg", "9769498B-8CAE-4E37-863B-379E77CFEF1E.jpg", 12014L, null, "https://crgoldenblob.blob.core.windows.net/images/9769498b-8cae-4e37-863b-379e77cfef1e.jpg" },
                    { new Guid("307bdfc8-0142-4371-a6da-9383a2bb5daf"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6841), ".jpg", "307BDFC8-0142-4371-A6DA-9383A2BB5DAF.jpg", 18034L, null, "https://crgoldenblob.blob.core.windows.net/images/307bdfc8-0142-4371-a6da-9383a2bb5daf.jpg" },
                    { new Guid("cdac7720-9734-4bf5-ab33-71cc0f3ee070"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6780), ".jpg", "CDAC7720-9734-4BF5-AB33-71CC0F3EE070.jpg", 24290L, null, "https://crgoldenblob.blob.core.windows.net/images/cdac7720-9734-4bf5-ab33-71cc0f3ee070.jpg" },
                    { new Guid("006a056d-33ad-4b0b-9169-3a6d02df6993"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6836), ".jpg", "006A056D-33AD-4B0B-9169-3A6D02DF6993.jpg", 21693L, null, "https://crgoldenblob.blob.core.windows.net/images/006a056d-33ad-4b0b-9169-3a6d02df6993.jpg" },
                    { new Guid("457f9796-7574-4c71-8d62-a70878441981"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6824), ".jpg", "457F9796-7574-4C71-8D62-A70878441981.jpg", 23321L, null, "https://crgoldenblob.blob.core.windows.net/images/457f9796-7574-4c71-8d62-a70878441981.jpg" },
                    { new Guid("ab17abc1-5491-4d6e-8974-fce35bb1159f"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6819), ".jpg", "AB17ABC1-5491-4D6E-8974-FCE35BB1159F.jpg", 17506L, null, "https://crgoldenblob.blob.core.windows.net/images/ab17abc1-5491-4d6e-8974-fce35bb1159f.jpg" },
                    { new Guid("1847baf5-dc0e-486d-af0b-bd0b23806205"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6814), ".jpg", "1847BAF5-DC0E-486D-AF0B-BD0B23806205.jpg", 22073L, null, "https://crgoldenblob.blob.core.windows.net/images/1847baf5-dc0e-486d-af0b-bd0b23806205.jpg" },
                    { new Guid("4fcf050a-4543-4878-9986-0db258095b97"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6808), ".jpg", "4FCF050A-4543-4878-9986-0DB258095B97.jpg", 19596L, null, "https://crgoldenblob.blob.core.windows.net/images/4fcf050a-4543-4878-9986-0db258095b97.jpg" },
                    { new Guid("910d6beb-4de9-43f6-a2a9-da0a01687ed5"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6803), ".jpg", "910D6BEB-4DE9-43F6-A2A9-DA0A01687ED5.jpg", 14740L, null, "https://crgoldenblob.blob.core.windows.net/images/910d6beb-4de9-43f6-a2a9-da0a01687ed5.jpg" },
                    { new Guid("4dfe104a-e281-4c4f-b4cb-cb5880e055c0"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6665), ".jpg", "4DFE104A-E281-4C4F-B4CB-CB5880E055C0.jpg", 18355L, null, "https://crgoldenblob.blob.core.windows.net/images/4dfe104a-e281-4c4f-b4cb-cb5880e055c0.jpg" },
                    { new Guid("07a598e1-3a67-4416-a030-30d734ac227d"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6791), ".jpg", "07A598E1-3A67-4416-A030-30D734AC227D.jpg", 15604L, null, "https://crgoldenblob.blob.core.windows.net/images/07a598e1-3a67-4416-a030-30d734ac227d.jpg" },
                    { new Guid("511dd9c9-ed5b-43a9-881a-1daeea1429be"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6830), ".jpg", "511DD9C9-ED5B-43A9-881A-1DAEEA1429BE.jpg", 15637L, null, "https://crgoldenblob.blob.core.windows.net/images/511dd9c9-ed5b-43a9-881a-1daeea1429be.jpg" },
                    { new Guid("2c279d1c-5583-4b37-a57a-ee353eca4209"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6659), ".jpg", "2C279D1C-5583-4B37-A57A-EE353ECA4209.jpg", 14889L, null, "https://crgoldenblob.blob.core.windows.net/images/2c279d1c-5583-4b37-a57a-ee353eca4209.jpg" },
                    { new Guid("0bb3fdf1-c58f-4840-8353-97141312244f"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6875), ".jpg", "0BB3FDF1-C58F-4840-8353-97141312244F.jpg", 13312L, null, "https://crgoldenblob.blob.core.windows.net/images/0bb3fdf1-c58f-4840-8353-97141312244f.jpg" },
                    { new Guid("6587d819-c4e5-47a5-b734-15c9b65b0c75"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6648), ".jpg", "6587D819-C4E5-47A5-B734-15C9B65B0C75.jpg", 17348L, null, "https://crgoldenblob.blob.core.windows.net/images/6587d819-c4e5-47a5-b734-15c9b65b0c75.jpg" },
                    { new Guid("c1ccf7f1-f51b-4c5f-a67c-be6a87639c7c"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6523), ".jpg", "C1CCF7F1-F51B-4C5F-A67C-BE6A87639C7C.jpg", 22160L, null, "https://crgoldenblob.blob.core.windows.net/images/c1ccf7f1-f51b-4c5f-a67c-be6a87639c7c.jpg" },
                    { new Guid("ce58fcba-e810-4bad-bb42-f1aac4d58242"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6516), ".jpg", "CE58FCBA-E810-4BAD-BB42-F1AAC4D58242.jpg", 23209L, null, "https://crgoldenblob.blob.core.windows.net/images/ce58fcba-e810-4bad-bb42-f1aac4d58242.jpg" },
                    { new Guid("6345fbc1-b23c-44e0-b9d0-fa334a2fe584"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6510), ".jpg", "6345FBC1-B23C-44E0-B9D0-FA334A2FE584.jpg", 18433L, null, "https://crgoldenblob.blob.core.windows.net/images/6345fbc1-b23c-44e0-b9d0-fa334a2fe584.jpg" },
                    { new Guid("fd90ee79-6fa6-40ff-87da-30bdd6b9f064"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6504), ".jpg", "FD90EE79-6FA6-40FF-87DA-30BDD6B9F064.jpg", 13198L, null, "https://crgoldenblob.blob.core.windows.net/images/fd90ee79-6fa6-40ff-87da-30bdd6b9f064.jpg" },
                    { new Guid("4edaa115-266c-43d8-8005-a5ee1abed2cf"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6498), ".jpg", "4EDAA115-266C-43D8-8005-A5EE1ABED2CF.jpg", 19789L, null, "https://crgoldenblob.blob.core.windows.net/images/4edaa115-266c-43d8-8005-a5ee1abed2cf.jpg" },
                    { new Guid("6ceef0fb-9da6-42a4-b23e-5a1d32abbb59"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6492), ".jpg", "6CEEF0FB-9DA6-42A4-B23E-5A1D32ABBB59.jpg", 18225L, null, "https://crgoldenblob.blob.core.windows.net/images/6ceef0fb-9da6-42a4-b23e-5a1d32abbb59.jpg" },
                    { new Guid("c3c9670e-53af-4935-8951-c986aad21b6a"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6485), ".jpg", "C3C9670E-53AF-4935-8951-C986AAD21B6A.jpg", 19415L, null, "https://crgoldenblob.blob.core.windows.net/images/c3c9670e-53af-4935-8951-c986aad21b6a.jpg" },
                    { new Guid("c2b2e3ee-0047-45b6-9e95-9f4ee51c5616"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6529), ".jpg", "C2B2E3EE-0047-45B6-9E95-9F4EE51C5616.jpg", 15712L, null, "https://crgoldenblob.blob.core.windows.net/images/c2b2e3ee-0047-45b6-9e95-9f4ee51c5616.jpg" },
                    { new Guid("cfdea2bf-c57e-4545-99a3-ebd7dec888ef"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6480), ".jpg", "CFDEA2BF-C57E-4545-99A3-EBD7DEC888EF.jpg", 19822L, null, "https://crgoldenblob.blob.core.windows.net/images/cfdea2bf-c57e-4545-99a3-ebd7dec888ef.jpg" },
                    { new Guid("4ed920d3-dd38-44e1-8c81-ad92e215585a"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6466), ".jpg", "4ED920D3-DD38-44E1-8C81-AD92E215585A.jpg", 24399L, null, "https://crgoldenblob.blob.core.windows.net/images/4ed920d3-dd38-44e1-8c81-ad92e215585a.jpg" },
                    { new Guid("c91e0338-46be-4b35-b9cd-c544cb01f9fa"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6459), ".jpg", "C91E0338-46BE-4B35-B9CD-C544CB01F9FA.jpg", 25702L, null, "https://crgoldenblob.blob.core.windows.net/images/c91e0338-46be-4b35-b9cd-c544cb01f9fa.jpg" },
                    { new Guid("4398a5ea-4f57-405d-867a-9e2bb1192c6b"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6452), ".jpg", "4398A5EA-4F57-405D-867A-9E2BB1192C6B.jpg", 21109L, null, "https://crgoldenblob.blob.core.windows.net/images/4398a5ea-4f57-405d-867a-9e2bb1192c6b.jpg" },
                    { new Guid("2c1d770a-57da-424a-9df8-d85851311db3"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6446), ".jpg", "2C1D770A-57DA-424A-9DF8-D85851311DB3.jpg", 16384L, null, "https://crgoldenblob.blob.core.windows.net/images/2c1d770a-57da-424a-9df8-d85851311db3.jpg" },
                    { new Guid("42a2d6b3-5926-4b53-9171-0107220e1630"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6439), ".jpg", "42A2D6B3-5926-4B53-9171-0107220E1630.jpg", 15271L, null, "https://crgoldenblob.blob.core.windows.net/images/42a2d6b3-5926-4b53-9171-0107220e1630.jpg" },
                    { new Guid("c4645bbe-a6ea-4788-b018-b5012deb5910"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6654), ".jpg", "C4645BBE-A6EA-4788-B018-B5012DEB5910.jpg", 15890L, null, "https://crgoldenblob.blob.core.windows.net/images/c4645bbe-a6ea-4788-b018-b5012deb5910.jpg" },
                    { new Guid("d2f2a7a5-4b94-4b72-b0ec-18a564fccccc"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6420), ".jpg", "D2F2A7A5-4B94-4B72-B0EC-18A564FCCCCC.jpg", 18870L, null, "https://crgoldenblob.blob.core.windows.net/images/d2f2a7a5-4b94-4b72-b0ec-18a564fccccc.jpg" },
                    { new Guid("2b1124af-bc6b-4a88-9089-0b0f513c495c"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6473), ".jpg", "2B1124AF-BC6B-4A88-9089-0B0F513C495C.jpg", 21016L, null, "https://crgoldenblob.blob.core.windows.net/images/2b1124af-bc6b-4a88-9089-0b0f513c495c.jpg" },
                    { new Guid("810b39bc-9f48-4144-b516-088e86701329"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6535), ".jpg", "810B39BC-9F48-4144-B516-088E86701329.jpg", 22040L, null, "https://crgoldenblob.blob.core.windows.net/images/810b39bc-9f48-4144-b516-088e86701329.jpg" },
                    { new Guid("b8a28f1e-0799-4a17-a087-f95da8902f8d"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6541), ".jpg", "B8A28F1E-0799-4A17-A087-F95DA8902F8D.jpg", 18980L, null, "https://crgoldenblob.blob.core.windows.net/images/b8a28f1e-0799-4a17-a087-f95da8902f8d.jpg" },
                    { new Guid("90267f43-731b-4cf0-adc5-17872bb3ea46"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6547), ".jpg", "90267F43-731B-4CF0-ADC5-17872BB3EA46.jpg", 19281L, null, "https://crgoldenblob.blob.core.windows.net/images/90267f43-731b-4cf0-adc5-17872bb3ea46.jpg" },
                    { new Guid("5032feb1-d204-4748-a275-b2b171e0e28f"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6643), ".jpg", "5032FEB1-D204-4748-A275-B2B171E0E28F.jpg", 19767L, null, "https://crgoldenblob.blob.core.windows.net/images/5032feb1-d204-4748-a275-b2b171e0e28f.jpg" },
                    { new Guid("5f72d5b6-0387-451b-b897-e1d97a4d899a"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6638), ".jpg", "5F72D5B6-0387-451B-B897-E1D97A4D899A.jpg", 15538L, null, "https://crgoldenblob.blob.core.windows.net/images/5f72d5b6-0387-451b-b897-e1d97a4d899a.jpg" },
                    { new Guid("f76c4cb2-4233-42c9-9e86-cb77b8e80498"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6633), ".jpg", "F76C4CB2-4233-42C9-9E86-CB77B8E80498.jpg", 13426L, null, "https://crgoldenblob.blob.core.windows.net/images/f76c4cb2-4233-42c9-9e86-cb77b8e80498.jpg" },
                    { new Guid("7f2de31f-b45c-42e3-9169-e540e632ec09"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6627), ".jpg", "7F2DE31F-B45C-42E3-9169-E540E632EC09.jpg", 18730L, null, "https://crgoldenblob.blob.core.windows.net/images/7f2de31f-b45c-42e3-9169-e540e632ec09.jpg" },
                    { new Guid("40bd2298-9f86-4b03-8d26-6dfc2b1a1fb0"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6622), ".jpg", "40BD2298-9F86-4B03-8D26-6DFC2B1A1FB0.jpg", 17490L, null, "https://crgoldenblob.blob.core.windows.net/images/40bd2298-9f86-4b03-8d26-6dfc2b1a1fb0.jpg" },
                    { new Guid("ec0ca3b9-e69f-48c9-94bc-289fcad8288b"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6616), ".jpg", "EC0CA3B9-E69F-48C9-94BC-289FCAD8288B.jpg", 13658L, null, "https://crgoldenblob.blob.core.windows.net/images/ec0ca3b9-e69f-48c9-94bc-289fcad8288b.jpg" },
                    { new Guid("7c0c8cd3-d692-459d-957e-c38ce2a168fa"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6610), ".jpg", "7C0C8CD3-D692-459D-957E-C38CE2A168FA.jpg", 17116L, null, "https://crgoldenblob.blob.core.windows.net/images/7c0c8cd3-d692-459d-957e-c38ce2a168fa.jpg" },
                    { new Guid("3824d42b-f808-47ec-b2a2-93d9c4e7840c"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6605), ".jpg", "3824D42B-F808-47EC-B2A2-93D9C4E7840C.jpg", 21539L, null, "https://crgoldenblob.blob.core.windows.net/images/3824d42b-f808-47ec-b2a2-93d9c4e7840c.jpg" },
                    { new Guid("0349d2ec-9650-41d2-acac-1202f44611b9"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6599), ".jpg", "0349D2EC-9650-41D2-ACAC-1202F44611B9.jpg", 21734L, null, "https://crgoldenblob.blob.core.windows.net/images/0349d2ec-9650-41d2-acac-1202f44611b9.jpg" },
                    { new Guid("f486622b-f81b-4be5-b6b3-c6b88f8f36f3"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6593), ".jpg", "F486622B-F81B-4BE5-B6B3-C6B88F8F36F3.jpg", 14474L, null, "https://crgoldenblob.blob.core.windows.net/images/f486622b-f81b-4be5-b6b3-c6b88f8f36f3.jpg" },
                    { new Guid("7a485726-06cf-4e0f-a501-0d310bcb17b8"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6587), ".jpg", "7A485726-06CF-4E0F-A501-0D310BCB17B8.jpg", 13785L, null, "https://crgoldenblob.blob.core.windows.net/images/7a485726-06cf-4e0f-a501-0d310bcb17b8.jpg" },
                    { new Guid("10439b59-147d-433f-ab6c-6794ebdb9ffa"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6581), ".jpg", "10439B59-147D-433F-AB6C-6794EBDB9FFA.jpg", 20611L, null, "https://crgoldenblob.blob.core.windows.net/images/10439b59-147d-433f-ab6c-6794ebdb9ffa.jpg" },
                    { new Guid("f3552e30-9ea3-4286-ab65-c0e72bca2348"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6575), ".jpg", "F3552E30-9EA3-4286-AB65-C0E72BCA2348.jpg", 15204L, null, "https://crgoldenblob.blob.core.windows.net/images/f3552e30-9ea3-4286-ab65-c0e72bca2348.jpg" },
                    { new Guid("69af227f-e8f1-4c10-849c-551d71888bdd"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6570), ".jpg", "69AF227F-E8F1-4C10-849C-551D71888BDD.jpg", 21982L, null, "https://crgoldenblob.blob.core.windows.net/images/69af227f-e8f1-4c10-849c-551d71888bdd.jpg" },
                    { new Guid("b188fc5c-0653-451e-a597-f9af8952ed70"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6564), ".jpg", "B188FC5C-0653-451E-A597-F9AF8952ED70.jpg", 23441L, null, "https://crgoldenblob.blob.core.windows.net/images/b188fc5c-0653-451e-a597-f9af8952ed70.jpg" },
                    { new Guid("b2fbd4d3-e933-4aa7-b3ef-d7fd6cbd8e1c"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6558), ".jpg", "B2FBD4D3-E933-4AA7-B3EF-D7FD6CBD8E1C.jpg", 14963L, null, "https://crgoldenblob.blob.core.windows.net/images/b2fbd4d3-e933-4aa7-b3ef-d7fd6cbd8e1c.jpg" },
                    { new Guid("7b23a584-847a-453c-8777-80078952f74b"), "image/jpeg", new DateTime(2019, 6, 8, 8, 34, 33, 512, DateTimeKind.Utc).AddTicks(6553), ".jpg", "7B23A584-847A-453C-8777-80078952F74B.jpg", 15383L, null, "https://crgoldenblob.blob.core.windows.net/images/7b23a584-847a-453c-8777-80078952f74b.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "Number", "Shipping", "Tax", "Total", "Updated", "UserId", "ShippingCountry", "ShippingCity", "ShippingZipCode", "ShippingState", "ShippingStreet" },
                values: new object[,]
                {
                    { new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), new DateTime(2019, 6, 8, 8, 34, 33, 591, DateTimeKind.Utc).AddTicks(7102), "5ED5AAAE", null, null, 1205.00m, null, new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), "USA", "AUSTIN", "78731-1791", "TX", "6805 N CAPITAL OF TEXAS HWY STE 312" },
                    { new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), new DateTime(2019, 6, 8, 8, 34, 33, 591, DateTimeKind.Utc).AddTicks(5953), "6B402277", null, null, 2214m, null, new Guid("b34f9a23-51a8-46e7-9a2c-5930d9423afb"), "USA", "AUSTIN", "78731-1791", "TX", "6805 N CAPITAL OF TEXAS HWY STE 312" },
                    { new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), new DateTime(2019, 6, 8, 8, 34, 33, 591, DateTimeKind.Utc).AddTicks(3624), "8A22920A", null, null, 959.00m, null, new Guid("c3a3042a-5516-448a-8895-ce361b5d0ab8"), "USA", "AUSTIN", "78731-1791", "TX", "6805 N CAPITAL OF TEXAS HWY STE 312" },
                    { new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), new DateTime(2019, 6, 8, 8, 34, 33, 591, DateTimeKind.Utc).AddTicks(4823), "10A57036", null, null, 2982m, null, new Guid("8bc6860d-3efe-4e27-b840-0c0706a07ca7"), "USA", "AUSTIN", "78731-1791", "TX", "6805 N CAPITAL OF TEXAS HWY STE 312" },
                    { new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), new DateTime(2019, 6, 8, 8, 34, 33, 591, DateTimeKind.Utc).AddTicks(2183), "54F0D8C7", null, null, 412m, null, new Guid("2ce77433-a490-4514-a8ae-344658d29d5f"), "USA", "AUSTIN", "78731-1791", "TX", "6805 N CAPITAL OF TEXAS HWY STE 312" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Created", "Description", "IsDownload", "Name", "QuantityPerUnit", "ReorderLevel", "Sku", "UnitPrice", "UnitsInStock", "UnitsOnOrder", "Updated" },
                values: new object[,]
                {
                    { new Guid("36f89c97-344a-4f59-aa00-9f875b6593da"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3901), null, false, "Pâté chinois", "24 boxes x 2 pies", 20, null, 24m, 115, 0, null },
                    { new Guid("c0eaea77-d109-4311-aa71-e5d2a6a4ad4d"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3895), null, false, "Tourtière", "16 pies", 10, null, 7.458m, 21, 0, null },
                    { new Guid("d88fe2f1-8dfa-49e3-b6b6-36ad136ddb47"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3889), null, false, "Perth Pasties", "48 pieces", 0, null, 32.8m, 0, 0, null },
                    { new Guid("f93a5554-5e8c-4d72-a0b8-17a29230cb98"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3882), null, false, "Filo Mix", "16 - 2 kg boxes", 25, null, 7m, 38, 0, null },
                    { new Guid("76b61cac-7040-4288-b6ff-e99d09f10962"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3875), null, false, "Manjimup Dried Apples", "50 - 300 g pkgs.", 10, null, 53m, 20, 0, null },
                    { new Guid("ae77969b-1abb-4015-8229-38f6d4c7f4bc"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3868), null, false, "Valkoinen suklaa", "12 - 100 g bars", 30, null, 16.25m, 65, 0, null },
                    { new Guid("4bdcfb51-9d36-4e9d-b43c-9a85e500e1ee"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3862), null, false, "Maxilaku", "24 - 50 g pkgs.", 15, null, 20m, 10, 60, null },
                    { new Guid("aa78c2b1-ff9c-447f-a415-fb80cddac6b4"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3856), null, false, "Chocolade", "10 pkgs.", 25, null, 12.75m, 15, 70, null },
                    { new Guid("3c1f3acc-01cf-4a28-aa77-90df94a6598d"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3850), null, false, "Zaanse koeken", "10 - 4 oz boxes", 0, null, 9.5m, 36, 0, null },
                    { new Guid("bdb95e44-52b3-4437-8e7a-6f2d9d1be9fd"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3843), null, false, "Spegesild", "4 - 450 g glasses", 0, null, 12m, 95, 0, null },
                    { new Guid("53d6fb26-8e37-4665-b089-a28597c94751"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3837), null, false, "Rogede sild", "1k pkg.", 15, null, 9.5m, 5, 70, null },
                    { new Guid("65bbc04c-242f-471a-8d40-c5bdeb9aee1c"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3829), null, false, "Gula Malacca", "20 - 2 kg bags", 15, null, 19.45m, 27, 0, null },
                    { new Guid("591c3e46-be08-44f2-9722-c295cc9d8591"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3735), null, false, "Ipoh Coffee", "16 - 500 g tins", 25, null, 46m, 17, 10, null },
                    { new Guid("ba6cf67f-2621-4292-97c6-adb6677f6c9c"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3727), null, false, "Singaporean Hokkien Fried Mee", "32 - 1 kg pkgs.", 0, null, 14m, 26, 0, null },
                    { new Guid("f8c165f6-cced-46c7-b976-df3a6e4c0c24"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3721), null, false, "Jack's New England Clam Chowder", "12 - 12 oz cans", 10, null, 9.65m, 85, 0, null },
                    { new Guid("bbd80bd0-356c-4da8-871f-e985b064bad0"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3715), null, false, "Boston Crab Meat", "24 - 4 oz tins", 30, null, 18.4m, 123, 0, null },
                    { new Guid("7f57b1c1-1931-4263-a1f9-0a257f1c49b8"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3907), null, false, "Gnocchi di nonna Alice", "24 - 250 g pkgs.", 30, null, 38m, 21, 10, null },
                    { new Guid("792b499c-12c8-4097-87a7-9daf21f9c850"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3708), null, false, "Chartreuse verte", "750 cc per bottle", 5, null, 18m, 69, 0, null },
                    { new Guid("88911341-95bd-434d-ab35-e7b4a599199c"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3914), null, false, "Ravioli Angelo", "24 - 250 g pkgs.", 20, null, 19.5m, 36, 0, null },
                    { new Guid("bbf389c8-ec1b-47f4-a00e-1ad7eca1c2ea"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3920), null, false, "Escargots de Bourgogne", "24 pieces", 20, null, 13.25m, 62, 0, null },
                    { new Guid("d9b8b94c-4865-4196-9ea6-e093c27e6666"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4046), null, false, "Röd Kaviar", "24 - 150 g jars", 5, null, 15m, 101, 0, null },
                    { new Guid("28aa496e-d877-4210-aa5f-481fdcfa4238"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4040), null, false, "Mozzarella di Giovanni", "24 - 200 g pkgs.", 0, null, 34.8m, 14, 0, null },
                    { new Guid("7a12b5ab-1c99-496a-aaf3-d7a8062677f3"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4033), null, false, "Flotemysost", "10 - 500 g pkgs.", 0, null, 21.5m, 26, 0, null },
                    { new Guid("47e058ae-7a73-4c5e-a631-7c55b5b64c13"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4028), null, false, "Outback Lager", "24 - 355 ml bottles", 30, null, 15m, 15, 10, null },
                    { new Guid("30f6cf4f-6d99-425a-ba31-7e23f48783b6"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4021), null, false, "Gudbrandsdalsost", "10 kg pkg.", 15, null, 36m, 26, 0, null },
                    { new Guid("0d2c5b7d-8c6e-4399-a18d-c45cb2a59ba8"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3982), null, false, "Scottish Longbreads", "10 boxes x 8 pieces", 15, null, 12.5m, 6, 10, null },
                    { new Guid("252f0916-6c20-4fd2-a5f4-7051881988f6"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3977), null, false, "Laughing Lumberjack Lager", "24 - 12 oz bottles", 10, null, 14m, 52, 0, null },
                    { new Guid("6cb52a87-0690-446c-a23b-64c43ec8f0db"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3971), null, false, "Louisiana Hot Spiced Okra", "24 - 8 oz jars", 20, null, 17m, 4, 100, null },
                    { new Guid("3a111262-f6b1-4c2f-bc6e-a88737dc1e8c"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3964), null, false, "Louisiana Fiery Hot Pepper Sauce", "32 - 8 oz bottles", 0, null, 21.05m, 76, 0, null },
                    { new Guid("7b76c7ee-8ff4-4079-b46b-0edb67270246"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3958), null, false, "Wimmers gute Semmelknödel", "20 bags x 4 pieces", 30, null, 33.25m, 22, 80, null },
                    { new Guid("e97b2e87-9b2f-4b13-99c6-0005c7732155"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3951), null, false, "Vegie-spread", "15 - 625 g jars", 5, null, 43.9m, 24, 0, null },
                    { new Guid("e46f4c5d-363e-46bc-ac44-712e4457c2ca"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3945), null, false, "Tarte au sucre", "48 pies", 0, null, 49.3m, 17, 0, null },
                    { new Guid("6b4260a2-a9ea-4587-91e5-8385996b7355"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3939), null, false, "Sirop d'érable", "24 - 500 ml bottles", 25, null, 28.5m, 113, 0, null },
                    { new Guid("f68e7b31-37ec-4260-b424-e7bd550ff9e3"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3933), null, false, "Camembert Pierrot", "15 - 300 g rounds", 0, null, 34m, 19, 0, null },
                    { new Guid("fb0a5251-e0bd-49a2-b01e-8bee844618e7"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3926), null, false, "Raclette Courdavault", "5 kg pkg.", 0, null, 55m, 79, 0, null },
                    { new Guid("c5cdcb4e-cab0-44bf-b0ef-55929c79a591"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4052), null, false, "Longlife Tofu", "5 kg pkg.", 5, null, 10m, 4, 20, null },
                    { new Guid("fa56cdca-9686-4b65-b2b7-4cd17f049178"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3701), null, false, "Côte de Blaye", "12 - 75 cl bottles", 15, null, 263.5m, 17, 0, null },
                    { new Guid("8f981368-9384-4112-97f1-897cbb45d5d9"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3497), null, false, "Alice Mutton", "20 - 1 kg tins", 0, null, 39m, 0, 0, null },
                    { new Guid("7419ba70-98a2-4f99-9a4e-a2784d865197"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3688), null, false, "Inlagd Sill", "24 - 250 g  jars", 20, null, 19m, 112, 0, null },
                    { new Guid("f446cbb4-cb33-4599-94e3-c8faea72c178"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3477), null, false, "Tofu", "40 - 100 g pkgs.", 5, null, 23.25m, 35, 0, null },
                    { new Guid("d592c3c5-9d21-4d73-b551-e452f8b18331"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3470), null, false, "Konbu", "2 kg box", 5, null, 6m, 24, 0, null },
                    { new Guid("ad663ab9-961e-453c-89f6-a6d368423097"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3463), null, false, "Queso Manchego La Pastora", "10 - 500 g pkgs.", 0, null, 38m, 86, 0, null },
                    { new Guid("1fe10cde-3ad6-4995-888b-18e4ff3f0bba"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3457), null, false, "Queso Cabrales", "1 kg pkg.", 0, null, 21m, 30, 30, null },
                    { new Guid("96ee285e-78a6-4d61-9b41-7de1c15b47dc"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3450), null, false, "Ikura", "12 - 200 ml jars", 0, null, 31m, 31, 0, null },
                    { new Guid("c3253f25-1310-44b5-b2e9-13553f005995"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3444), null, false, "Mishi Kobe Niku", "18 - 500 g pkgs.", 0, null, 97m, 29, 0, null },
                    { new Guid("a9765975-2f58-4489-be32-065ca6c01019"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3436), null, false, "Northwoods Cranberry Sauce", "12 - 12 oz jars", 0, null, 40m, 6, 0, null },
                    { new Guid("3235c9ab-c613-4136-b602-f8bcb6fda51e"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3428), null, false, "Uncle Bob's Organic Dried Pears", "12 - 1 lb pkgs.", 10, null, 30m, 15, 0, null },
                    { new Guid("2b7140e8-86f1-4602-95a1-2335fa3e3cc9"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3421), null, false, "Grandma's Boysenberry Spread", "12 - 8 oz jars", 25, null, 25m, 120, 0, null },
                    { new Guid("54a0644c-9fac-4bdb-944c-d1f55e638cdc"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3414), null, false, "Chef Anton's Gumbo Mix", "36 boxes", 0, null, 21.35m, 0, 0, null },
                    { new Guid("0c201103-a52f-4e2c-b235-fb553e0b3942"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3407), null, false, "Chef Anton's Cajun Seasoning", "48 - 6 oz jars", 0, null, 22m, 53, 0, null },
                    { new Guid("71ffe75c-9832-4f6c-8c26-cb7343c8bc15"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3398), null, false, "Aniseed Syrup", "12 - 550 ml bottles", 25, null, 10m, 13, 70, null },
                    { new Guid("c59dbf6f-9378-4bad-9196-d8051cc5a6bf"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3358), null, false, "Chang", "24 - 12 oz bottles", 25, null, 19m, 17, 40, null },
                    { new Guid("dbcb5421-8b2e-48a7-b60f-5cecb118fc69"), true, new DateTime(2019, 6, 8, 8, 34, 13, 593, DateTimeKind.Utc).AddTicks(8455), null, false, "Chai", "10 boxes x 20 bags", 10, null, 18m, 39, 0, null },
                    { new Guid("9eb2d006-e87a-4d10-ae7f-e4ebb5e0b2e6"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4059), null, false, "Rhönbräu Klosterbier", "24 - 0.5 l bottles", 25, null, 7.75m, 125, 0, null },
                    { new Guid("50b5f7da-2c36-40b0-ac7f-2b8c898f7f8b"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3484), null, false, "Genen Shouyu", "24 - 250 ml bottles", 5, null, 15.5m, 9, 0, null },
                    { new Guid("4943b208-7656-4b34-a0ee-28af101d88cb"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3490), null, false, "Pavlova", "32 - 500 g boxes", 10, null, 17.45m, 29, 0, null },
                    { new Guid("7dd0c948-18ca-46a9-a039-93cc513f8866"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3505), null, false, "Carnarvon Tigers", "16 kg pkg.", 0, null, 62.5m, 42, 0, null },
                    { new Guid("115a8153-a552-445f-a288-ca2b65505ec0"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3569), null, false, "Teatime Chocolate Biscuits", "10 boxes x 12 pieces", 5, null, 9.2m, 25, 0, null },
                    { new Guid("4951197e-4bbd-43df-938f-ed51d9e0a155"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3681), null, false, "Steeleye Stout", "24 - 12 oz bottles", 15, null, 18m, 20, 0, null },
                    { new Guid("2e78c55e-93ac-4c85-9e15-966d4e7f60de"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3674), null, false, "Sasquatch Ale", "24 - 12 oz bottles", 15, null, 14m, 111, 0, null },
                    { new Guid("943e1552-1a57-49cb-8a25-e0c8307d14e7"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3668), null, false, "Geitost", "500 g", 20, null, 2.5m, 112, 0, null },
                    { new Guid("601dd021-51c6-4fda-9149-d885aceeb881"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3662), null, false, "Mascarpone Fabioli", "24 - 200 g pkgs.", 25, null, 32m, 9, 40, null },
                    { new Guid("24e59514-5d0f-4361-b91d-40bbe3d75161"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3654), null, false, "Gorgonzola Telino", "12 - 100 g pkgs", 20, null, 12.5m, 0, 70, null },
                    { new Guid("c5943fc7-0fa2-4fa2-b190-8bf5930cd3f0"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3647), null, false, "Nord-Ost Matjeshering", "10 - 200 g glasses", 15, null, 25.89m, 10, 0, null },
                    { new Guid("baac6e9a-c4ed-4505-9ba6-26c84b3ddc58"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3640), null, false, "Thüringer Rostbratwurst", "50 bags x 30 sausgs.", 0, null, 123.79m, 0, 0, null },
                    { new Guid("75b79c13-fd6e-413c-9bc7-058f637dd5d7"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3695), null, false, "Gravad lax", "12 - 500 g pkgs.", 25, null, 26m, 11, 50, null },
                    { new Guid("e84b6e4d-5255-42fd-ae73-96255baaa720"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3633), null, false, "Rössle Sauerkraut", "25 - 825 g cans", 0, null, 45.6m, 26, 0, null },
                    { new Guid("c9a7a661-f78f-468a-adf7-bb9d174ad2e6"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3616), null, false, "Gumbär Gummibärchen", "100 - 250 g bags", 0, null, 31.23m, 15, 0, null },
                    { new Guid("a88e13f6-b13f-4919-8ba1-2c09ff303180"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3609), null, false, "NuNuCa Nuß-Nougat-Creme", "20 - 450 g glasses", 30, null, 14m, 76, 0, null },
                    { new Guid("5beb274b-0c04-4ded-8ab2-30a5ef308908"), false, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3602), null, false, "Guaraná Fantástica", "12 - 355 ml cans", 0, null, 4.5m, 20, 0, null },
                    { new Guid("a9e9919a-b904-4a15-9896-d5272425a051"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3596), null, false, "Tunnbröd", "12 - 250 g pkgs.", 25, null, 9m, 61, 0, null },
                    { new Guid("092c5d2d-0b92-44ee-9a66-2299edd4c481"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3590), null, false, "Gustaf's Knäckebröd", "24 - 500 g pkgs.", 25, null, 21m, 104, 0, null },
                    { new Guid("e8219e12-e38b-4a42-9ee7-30383d3b10a0"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3583), null, false, "Sir Rodney's Scones", "24 pkgs. x 4 pieces", 5, null, 10m, 3, 40, null },
                    { new Guid("c2f164eb-c057-4d41-9f13-34deedf095a7"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3577), null, false, "Sir Rodney's Marmalade", "30 gift boxes", 0, null, 81m, 40, 0, null },
                    { new Guid("526cf57b-827c-4c97-baea-7ddf4bdea1cc"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(3625), null, false, "Schoggi Schokolade", "100 - 100 g pieces", 30, null, 43.9m, 49, 0, null },
                    { new Guid("f2f72562-5a05-4ecb-8568-a12cffc4827f"), true, new DateTime(2019, 6, 8, 8, 34, 13, 594, DateTimeKind.Utc).AddTicks(4065), null, false, "Lakkalikööri", "500 ml", 20, null, 18m, 57, 0, null }
                });

            migrationBuilder.InsertData(
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId", "Created", "Quantity", "Updated" },
                values: new object[,]
                {
                    { new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), new Guid("ad663ab9-961e-453c-89f6-a6d368423097"), new DateTime(2019, 6, 8, 8, 34, 33, 630, DateTimeKind.Utc).AddTicks(4809), 18m, null },
                    { new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), new Guid("1fe10cde-3ad6-4995-888b-18e4ff3f0bba"), new DateTime(2019, 6, 8, 8, 34, 33, 629, DateTimeKind.Utc).AddTicks(8253), 2m, null },
                    { new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), new Guid("d592c3c5-9d21-4d73-b551-e452f8b18331"), new DateTime(2019, 6, 8, 8, 34, 33, 631, DateTimeKind.Utc).AddTicks(977), 20m, null },
                    { new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), new Guid("96ee285e-78a6-4d61-9b41-7de1c15b47dc"), new DateTime(2019, 6, 8, 8, 34, 33, 629, DateTimeKind.Utc).AddTicks(2211), 48m, null },
                    { new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), new Guid("f446cbb4-cb33-4599-94e3-c8faea72c178"), new DateTime(2019, 6, 8, 8, 34, 33, 631, DateTimeKind.Utc).AddTicks(7012), 36m, null },
                    { new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), new Guid("c3253f25-1310-44b5-b2e9-13553f005995"), new DateTime(2019, 6, 8, 8, 34, 33, 628, DateTimeKind.Utc).AddTicks(6095), 26m, null },
                    { new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), new Guid("a9765975-2f58-4489-be32-065ca6c01019"), new DateTime(2019, 6, 8, 8, 34, 33, 627, DateTimeKind.Utc).AddTicks(7736), 10m, null },
                    { new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), new Guid("50b5f7da-2c36-40b0-ac7f-2b8c898f7f8b"), new DateTime(2019, 6, 8, 8, 34, 33, 632, DateTimeKind.Utc).AddTicks(3089), 16m, null },
                    { new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), new Guid("3235c9ab-c613-4136-b602-f8bcb6fda51e"), new DateTime(2019, 6, 8, 8, 34, 33, 627, DateTimeKind.Utc).AddTicks(1676), 2m, null },
                    { new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), new Guid("2b7140e8-86f1-4602-95a1-2335fa3e3cc9"), new DateTime(2019, 6, 8, 8, 34, 33, 626, DateTimeKind.Utc).AddTicks(5525), 16m, null },
                    { new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), new Guid("dbcb5421-8b2e-48a7-b60f-5cecb118fc69"), new DateTime(2019, 6, 8, 8, 34, 33, 623, DateTimeKind.Utc).AddTicks(3021), 8m, null },
                    { new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), new Guid("54a0644c-9fac-4bdb-944c-d1f55e638cdc"), new DateTime(2019, 6, 8, 8, 34, 33, 625, DateTimeKind.Utc).AddTicks(9436), 20m, null },
                    { new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), new Guid("0c201103-a52f-4e2c-b235-fb553e0b3942"), new DateTime(2019, 6, 8, 8, 34, 33, 625, DateTimeKind.Utc).AddTicks(3299), 6m, null },
                    { new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), new Guid("c59dbf6f-9378-4bad-9196-d8051cc5a6bf"), new DateTime(2019, 6, 8, 8, 34, 33, 624, DateTimeKind.Utc).AddTicks(1034), 12m, null },
                    { new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), new Guid("71ffe75c-9832-4f6c-8c26-cb7343c8bc15"), new DateTime(2019, 6, 8, 8, 34, 33, 624, DateTimeKind.Utc).AddTicks(7097), 4m, null }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "ChargeId", "Created", "Currency", "CustomerCode", "Description", "OrderId", "TokenId", "Updated", "UserId" },
                values: new object[,]
                {
                    { new Guid("bf1f6be6-a662-49b7-b1ff-df80d6328b1b"), 206m, "7D327AC2-8F8A-406B-A8F5-F68148B0D065", new DateTime(2019, 6, 8, 8, 34, 33, 600, DateTimeKind.Utc).AddTicks(3448), "USD", "097B52D8-34E6-4940-BD11-B7F7A0CC6D48", null, new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), "C7ED58F3-72EE-4D27-A143-CDCE2D966EE3", null, new Guid("2ce77433-a490-4514-a8ae-344658d29d5f") },
                    { new Guid("bb33204d-4fc6-41be-adaf-371e39a589a6"), 206m, "FC3F98C9-2A6E-4358-A467-B6AFAF1F2863", new DateTime(2019, 6, 8, 8, 34, 33, 602, DateTimeKind.Utc).AddTicks(1363), "USD", "4877A522-EEEC-4E1C-8E9E-5B799BC179D2", null, new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f"), "0E67B8FE-FA89-4731-8853-8D05AA3544F2", null, new Guid("2ce77433-a490-4514-a8ae-344658d29d5f") },
                    { new Guid("ad89c796-8c77-425c-8d83-0cd02cf930fd"), 479.50m, "9E9C000B-F9FC-4192-9A38-80166B9CA9FB", new DateTime(2019, 6, 8, 8, 34, 33, 603, DateTimeKind.Utc).AddTicks(4227), "USD", "7C2628DA-CF13-4055-BE71-1711191DA921", null, new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), "1CBC4524-EBF2-48F2-8271-756A380AA1AC", null, new Guid("c3a3042a-5516-448a-8895-ce361b5d0ab8") },
                    { new Guid("9a50ee25-3d3c-4cfe-ba45-cc0fc9869e35"), 479.50m, "076A81EB-5A44-4703-A6FA-D9056CF9F0A7", new DateTime(2019, 6, 8, 8, 34, 33, 604, DateTimeKind.Utc).AddTicks(6853), "USD", "3AB09185-61E0-4A90-9745-EA2554B4B1F0", null, new Guid("c81ac9bb-6f43-48db-8e01-0986f9d697de"), "5EBA26DB-0D87-4F21-B525-8C80BEA5D6C5", null, new Guid("c3a3042a-5516-448a-8895-ce361b5d0ab8") },
                    { new Guid("ec33f601-e37d-4025-84dc-1abd348da4e8"), 1491m, "F2BA9195-EECE-4C9F-9B7C-E6D568E428C0", new DateTime(2019, 6, 8, 8, 34, 33, 606, DateTimeKind.Utc).AddTicks(1519), "USD", "B0922424-DAAA-4BD8-9EA3-77EA51AF0CDC", null, new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), "3B93FFB4-9B0D-46CF-A0F6-3B646E26B8FE", null, new Guid("8bc6860d-3efe-4e27-b840-0c0706a07ca7") },
                    { new Guid("9ffe2a32-cacb-4e8e-9bc1-b1ebe2b79f7f"), 1491m, "02CB9445-BD75-4FE3-A5C4-066C0C082E1A", new DateTime(2019, 6, 8, 8, 34, 33, 607, DateTimeKind.Utc).AddTicks(4859), "USD", "EB1CB200-2EEB-4926-AFC2-5C52B4C8B84A", null, new Guid("7193023b-bdba-4c89-b568-a2f2f55e2c92"), "FE07E852-F778-460B-B7B7-CA15E344D632", null, new Guid("8bc6860d-3efe-4e27-b840-0c0706a07ca7") },
                    { new Guid("f9f1c58b-c77f-4c0f-bf70-4259f9f9386c"), 602.50m, "DF2954AA-04AB-47D7-8E9F-17A7D55B6043", new DateTime(2019, 6, 8, 8, 34, 33, 612, DateTimeKind.Utc).AddTicks(5279), "USD", "D8F88682-B3F6-4786-A7E0-327C9817A9E7", null, new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), "037A4FA3-C356-4AE2-A2F2-4FC4A9596886", null, new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f") },
                    { new Guid("3e94d6b6-61eb-46ae-9b49-f0759f02b1a9"), 602.50m, "89E0D67B-137F-49DD-A885-85C2DEBE5A1C", new DateTime(2019, 6, 8, 8, 34, 33, 611, DateTimeKind.Utc).AddTicks(2659), "USD", "8CAFD586-740C-44CB-B238-BC23BB835782", null, new Guid("cceaf62f-f10d-4039-980a-0e8ea09f17f4"), "7C7BC60B-3BF7-4B92-AD96-02AE97A1BF8C", null, new Guid("6dadb928-e9ed-4115-a2db-f0eff0f4cf8f") },
                    { new Guid("671e6f92-d37b-4491-9539-ed8d68c4c4eb"), 1107m, "25F2AA01-C5F0-4490-8ED9-6B4751E68630", new DateTime(2019, 6, 8, 8, 34, 33, 608, DateTimeKind.Utc).AddTicks(7339), "USD", "7F4A4D1B-71C4-46FE-AE20-294747455DC5", null, new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), "7ECDF810-CB14-4143-938A-5AB9DC6E2A1C", null, new Guid("b34f9a23-51a8-46e7-9a2c-5930d9423afb") },
                    { new Guid("b10118d8-7c9d-48ef-9dfb-dd782246d937"), 1107m, "2806DC54-1EA1-443F-BCCF-3779C39BDBB5", new DateTime(2019, 6, 8, 8, 34, 33, 610, DateTimeKind.Utc).AddTicks(113), "USD", "7849EAB2-8A94-4216-A016-EA9851C98072", null, new Guid("91f088b7-c393-42e1-817d-aadf3da1a892"), "230E5B6A-AC4F-4907-AC25-242CE0CF9E42", null, new Guid("b34f9a23-51a8-46e7-9a2c-5930d9423afb") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductId", "CategoryId", "Created", "Updated" },
                values: new object[,]
                {
                    { new Guid("a88e13f6-b13f-4919-8ba1-2c09ff303180"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(7040), null },
                    { new Guid("4951197e-4bbd-43df-938f-ed51d9e0a155"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(1467), null },
                    { new Guid("2e78c55e-93ac-4c85-9e15-966d4e7f60de"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(1067), null },
                    { new Guid("f68e7b31-37ec-4260-b424-e7bd550ff9e3"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(1848), null },
                    { new Guid("943e1552-1a57-49cb-8a25-e0c8307d14e7"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(652), null },
                    { new Guid("f2f72562-5a05-4ecb-8568-a12cffc4827f"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(9832), null },
                    { new Guid("601dd021-51c6-4fda-9149-d885aceeb881"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(200), null },
                    { new Guid("24e59514-5d0f-4361-b91d-40bbe3d75161"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(9790), null },
                    { new Guid("6b4260a2-a9ea-4587-91e5-8385996b7355"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(2299), null },
                    { new Guid("c5943fc7-0fa2-4fa2-b190-8bf5930cd3f0"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(9256), null },
                    { new Guid("baac6e9a-c4ed-4505-9ba6-26c84b3ddc58"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(8701), null },
                    { new Guid("5beb274b-0c04-4ded-8ab2-30a5ef308908"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(6619), null },
                    { new Guid("fb0a5251-e0bd-49a2-b01e-8bee844618e7"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(1447), null },
                    { new Guid("e84b6e4d-5255-42fd-ae73-96255baaa720"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(8260), null },
                    { new Guid("7b76c7ee-8ff4-4079-b46b-0edb67270246"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(3511), null },
                    { new Guid("526cf57b-827c-4c97-baea-7ddf4bdea1cc"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(7856), null },
                    { new Guid("e97b2e87-9b2f-4b13-99c6-0005c7732155"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(3110), null },
                    { new Guid("c9a7a661-f78f-468a-adf7-bb9d174ad2e6"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(7451), null },
                    { new Guid("e46f4c5d-363e-46bc-ac44-712e4457c2ca"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(2706), null },
                    { new Guid("bbd80bd0-356c-4da8-871f-e985b064bad0"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(3517), null },
                    { new Guid("75b79c13-fd6e-413c-9bc7-058f637dd5d7"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(2302), null },
                    { new Guid("ae77969b-1abb-4015-8229-38f6d4c7f4bc"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(7629), null },
                    { new Guid("f93a5554-5e8c-4d72-a0b8-17a29230cb98"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(8434), null },
                    { new Guid("4bdcfb51-9d36-4e9d-b43c-9a85e500e1ee"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(7227), null },
                    { new Guid("aa78c2b1-ff9c-447f-a415-fb80cddac6b4"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(6800), null },
                    { new Guid("d88fe2f1-8dfa-49e3-b6b6-36ad136ddb47"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(8863), null },
                    { new Guid("3c1f3acc-01cf-4a28-aa77-90df94a6598d"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(6398), null },
                    { new Guid("bdb95e44-52b3-4437-8e7a-6f2d9d1be9fd"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(5994), null },
                    { new Guid("c0eaea77-d109-4311-aa71-e5d2a6a4ad4d"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(9376), null },
                    { new Guid("53d6fb26-8e37-4665-b089-a28597c94751"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(5593), null },
                    { new Guid("7419ba70-98a2-4f99-9a4e-a2784d865197"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(1868), null },
                    { new Guid("65bbc04c-242f-471a-8d40-c5bdeb9aee1c"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(5165), null },
                    { new Guid("591c3e46-be08-44f2-9722-c295cc9d8591"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(4763), null },
                    { new Guid("ba6cf67f-2621-4292-97c6-adb6677f6c9c"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(4360), null },
                    { new Guid("7f57b1c1-1931-4263-a1f9-0a257f1c49b8"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(191), null },
                    { new Guid("f8c165f6-cced-46c7-b976-df3a6e4c0c24"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(3953), null },
                    { new Guid("a9e9919a-b904-4a15-9896-d5272425a051"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(6218), null },
                    { new Guid("88911341-95bd-434d-ab35-e7b4a599199c"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(637), null },
                    { new Guid("792b499c-12c8-4097-87a7-9daf21f9c850"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(3116), null },
                    { new Guid("fa56cdca-9686-4b65-b2b7-4cd17f049178"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(2715), null },
                    { new Guid("bbf389c8-ec1b-47f4-a00e-1ad7eca1c2ea"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(1046), null },
                    { new Guid("36f89c97-344a-4f59-aa00-9f875b6593da"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(9785), null },
                    { new Guid("3a111262-f6b1-4c2f-bc6e-a88737dc1e8c"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(3955), null },
                    { new Guid("76b61cac-7040-4288-b6ff-e99d09f10962"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 641, DateTimeKind.Utc).AddTicks(8031), null },
                    { new Guid("1fe10cde-3ad6-4995-888b-18e4ff3f0bba"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(1295), null },
                    { new Guid("0c201103-a52f-4e2c-b235-fb553e0b3942"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(8256), null },
                    { new Guid("d592c3c5-9d21-4d73-b551-e452f8b18331"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(2125), null },
                    { new Guid("c5cdcb4e-cab0-44bf-b0ef-55929c79a591"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(8575), null },
                    { new Guid("47e058ae-7a73-4c5e-a631-7c55b5b64c13"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(6814), null },
                    { new Guid("ad663ab9-961e-453c-89f6-a6d368423097"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(1700), null },
                    { new Guid("54a0644c-9fac-4bdb-944c-d1f55e638cdc"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(8736), null },
                    { new Guid("f446cbb4-cb33-4599-94e3-c8faea72c178"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(2535), null },
                    { new Guid("092c5d2d-0b92-44ee-9a66-2299edd4c481"), new Guid("7fdc3396-a54c-400e-b6d8-1df6958c89fd"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(5813), null },
                    { new Guid("96ee285e-78a6-4d61-9b41-7de1c15b47dc"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(885), null },
                    { new Guid("2b7140e8-86f1-4602-95a1-2335fa3e3cc9"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(9209), null },
                    { new Guid("c3253f25-1310-44b5-b2e9-13553f005995"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(480), null },
                    { new Guid("28aa496e-d877-4210-aa5f-481fdcfa4238"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(7675), null },
                    { new Guid("d9b8b94c-4865-4196-9ea6-e093c27e6666"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(8157), null },
                    { new Guid("a9765975-2f58-4489-be32-065ca6c01019"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(45), null },
                    { new Guid("7a12b5ab-1c99-496a-aaf3-d7a8062677f3"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(7248), null },
                    { new Guid("50b5f7da-2c36-40b0-ac7f-2b8c898f7f8b"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(2938), null },
                    { new Guid("30f6cf4f-6d99-425a-ba31-7e23f48783b6"), new Guid("ec675684-09d8-4ee9-bf29-e2b561bb8a1b"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(6371), null },
                    { new Guid("252f0916-6c20-4fd2-a5f4-7051881988f6"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(5211), null },
                    { new Guid("dbcb5421-8b2e-48a7-b60f-5cecb118fc69"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(5534), null },
                    { new Guid("e8219e12-e38b-4a42-9ee7-30383d3b10a0"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(5403), null },
                    { new Guid("6cb52a87-0690-446c-a23b-64c43ec8f0db"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(4364), null },
                    { new Guid("c2f164eb-c057-4d41-9f13-34deedf095a7"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(4980), null },
                    { new Guid("c59dbf6f-9378-4bad-9196-d8051cc5a6bf"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(7331), null },
                    { new Guid("115a8153-a552-445f-a288-ca2b65505ec0"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(4581), null },
                    { new Guid("3235c9ab-c613-4136-b602-f8bcb6fda51e"), new Guid("7030a699-7b00-4a85-aad6-61afea983df8"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(9638), null },
                    { new Guid("9eb2d006-e87a-4d10-ae7f-e4ebb5e0b2e6"), new Guid("8880372b-ec84-42e1-bce7-941c2cf3db34"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(9389), null },
                    { new Guid("8f981368-9384-4112-97f1-897cbb45d5d9"), new Guid("bb71e15b-4112-4b7e-8154-4400034f0463"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(3767), null },
                    { new Guid("71ffe75c-9832-4f6c-8c26-cb7343c8bc15"), new Guid("f6b8e946-172e-4063-bdcb-86ea0326f09d"), new DateTime(2019, 6, 8, 8, 34, 33, 639, DateTimeKind.Utc).AddTicks(7815), null },
                    { new Guid("0d2c5b7d-8c6e-4399-a18d-c45cb2a59ba8"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 642, DateTimeKind.Utc).AddTicks(5818), null },
                    { new Guid("4943b208-7656-4b34-a0ee-28af101d88cb"), new Guid("c8a330d6-e2dc-457d-a3a2-445aacf70339"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(3341), null },
                    { new Guid("7dd0c948-18ca-46a9-a039-93cc513f8866"), new Guid("585addaf-e033-4b4e-b461-4dee169e0b47"), new DateTime(2019, 6, 8, 8, 34, 33, 640, DateTimeKind.Utc).AddTicks(4179), null }
                });

            migrationBuilder.InsertData(
                table: "ProductFiles",
                columns: new[] { "ProductId", "FileId", "Created", "IsPrimary", "Updated" },
                values: new object[,]
                {
                    { new Guid("f93a5554-5e8c-4d72-a0b8-17a29230cb98"), new Guid("c9cc388f-6645-4c31-b19c-f566ee06c0dc"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(6720), true, null },
                    { new Guid("c0eaea77-d109-4311-aa71-e5d2a6a4ad4d"), new Guid("c68ebcdd-7cc3-45a0-b088-29dc950dae60"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(8265), true, null },
                    { new Guid("d88fe2f1-8dfa-49e3-b6b6-36ad136ddb47"), new Guid("a8189d9d-7185-4c2c-bf48-f0cc797a2acc"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(7465), true, null },
                    { new Guid("d9b8b94c-4865-4196-9ea6-e093c27e6666"), new Guid("681ffa4f-6d3b-460c-be10-a8376eb7bb15"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(3026), true, null },
                    { new Guid("9eb2d006-e87a-4d10-ae7f-e4ebb5e0b2e6"), new Guid("0bb3fdf1-c58f-4840-8353-97141312244f"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(4523), true, null },
                    { new Guid("36f89c97-344a-4f59-aa00-9f875b6593da"), new Guid("8703e152-aeaa-43f4-b607-3b803f6ab773"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(9107), true, null },
                    { new Guid("c5cdcb4e-cab0-44bf-b0ef-55929c79a591"), new Guid("183f872c-1a26-4f44-ac02-63cba826ff59"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(3779), true, null },
                    { new Guid("3a111262-f6b1-4c2f-bc6e-a88737dc1e8c"), new Guid("ab17abc1-5491-4d6e-8974-fce35bb1159f"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(6797), true, null },
                    { new Guid("7f57b1c1-1931-4263-a1f9-0a257f1c49b8"), new Guid("212c48d4-38ef-42b3-951b-2a7dda0a0746"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(9871), true, null },
                    { new Guid("7b76c7ee-8ff4-4079-b46b-0edb67270246"), new Guid("1847baf5-dc0e-486d-af0b-bd0b23806205"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(6018), true, null },
                    { new Guid("e97b2e87-9b2f-4b13-99c6-0005c7732155"), new Guid("4fcf050a-4543-4878-9986-0db258095b97"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(5271), true, null },
                    { new Guid("76b61cac-7040-4288-b6ff-e99d09f10962"), new Guid("771cd746-df18-4b3d-b7a3-68d426fe7bb9"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(5962), true, null },
                    { new Guid("e46f4c5d-363e-46bc-ac44-712e4457c2ca"), new Guid("910d6beb-4de9-43f6-a2a9-da0a01687ed5"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(4490), true, null },
                    { new Guid("252f0916-6c20-4fd2-a5f4-7051881988f6"), new Guid("511dd9c9-ed5b-43a9-881a-1daeea1429be"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(8300), true, null },
                    { new Guid("6b4260a2-a9ea-4587-91e5-8385996b7355"), new Guid("8d12d30e-899e-4533-8faa-11716affdefe"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(3745), true, null },
                    { new Guid("28aa496e-d877-4210-aa5f-481fdcfa4238"), new Guid("80d595ef-d82c-4c55-a4bd-60b29d4953e9"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(2225), true, null },
                    { new Guid("0d2c5b7d-8c6e-4399-a18d-c45cb2a59ba8"), new Guid("006a056d-33ad-4b0b-9169-3a6d02df6993"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(9185), true, null },
                    { new Guid("30f6cf4f-6d99-425a-ba31-7e23f48783b6"), new Guid("307bdfc8-0142-4371-a6da-9383a2bb5daf"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(9945), true, null },
                    { new Guid("fb0a5251-e0bd-49a2-b01e-8bee844618e7"), new Guid("4f71a1f9-bf6f-4653-ae85-a6dad07b80e6"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(2218), true, null },
                    { new Guid("47e058ae-7a73-4c5e-a631-7c55b5b64c13"), new Guid("9769498b-8cae-4e37-863b-379e77cfef1e"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(698), true, null },
                    { new Guid("bbf389c8-ec1b-47f4-a00e-1ad7eca1c2ea"), new Guid("cdac7720-9734-4bf5-ab33-71cc0f3ee070"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(1417), true, null },
                    { new Guid("88911341-95bd-434d-ab35-e7b4a599199c"), new Guid("d28c4f4f-6048-4a93-a47a-d7db0c81a27a"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(666), true, null },
                    { new Guid("7a12b5ab-1c99-496a-aaf3-d7a8062677f3"), new Guid("b4ecc589-9e7f-4d00-bc93-4d87e97441fb"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(1470), true, null },
                    { new Guid("f68e7b31-37ec-4260-b424-e7bd550ff9e3"), new Guid("07a598e1-3a67-4416-a030-30d734ac227d"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(2993), true, null },
                    { new Guid("6cb52a87-0690-446c-a23b-64c43ec8f0db"), new Guid("457f9796-7574-4c71-8d62-a70878441981"), new DateTime(2019, 6, 8, 8, 34, 33, 655, DateTimeKind.Utc).AddTicks(7552), true, null },
                    { new Guid("601dd021-51c6-4fda-9149-d885aceeb881"), new Guid("40bd2298-9f86-4b03-8d26-6dfc2b1a1fb0"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(1381), true, null },
                    { new Guid("4bdcfb51-9d36-4e9d-b43c-9a85e500e1ee"), new Guid("b589c46f-9572-4088-ba25-a5f67364b2ec"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(4422), true, null },
                    { new Guid("e8219e12-e38b-4a42-9ee7-30383d3b10a0"), new Guid("b2fbd4d3-e933-4aa7-b3ef-d7fd6cbd8e1c"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(2911), true, null },
                    { new Guid("c2f164eb-c057-4d41-9f13-34deedf095a7"), new Guid("7b23a584-847a-453c-8777-80078952f74b"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(2158), true, null },
                    { new Guid("115a8153-a552-445f-a288-ca2b65505ec0"), new Guid("90267f43-731b-4cf0-adc5-17872bb3ea46"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(1383), true, null },
                    { new Guid("7dd0c948-18ca-46a9-a039-93cc513f8866"), new Guid("b8a28f1e-0799-4a17-a087-f95da8902f8d"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(623), true, null },
                    { new Guid("8f981368-9384-4112-97f1-897cbb45d5d9"), new Guid("810b39bc-9f48-4144-b516-088e86701329"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(9869), true, null },
                    { new Guid("4943b208-7656-4b34-a0ee-28af101d88cb"), new Guid("c2b2e3ee-0047-45b6-9e95-9f4ee51c5616"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(9059), true, null },
                    { new Guid("50b5f7da-2c36-40b0-ac7f-2b8c898f7f8b"), new Guid("c1ccf7f1-f51b-4c5f-a67c-be6a87639c7c"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(8228), true, null },
                    { new Guid("f446cbb4-cb33-4599-94e3-c8faea72c178"), new Guid("ce58fcba-e810-4bad-bb42-f1aac4d58242"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(7472), true, null },
                    { new Guid("d592c3c5-9d21-4d73-b551-e452f8b18331"), new Guid("6345fbc1-b23c-44e0-b9d0-fa334a2fe584"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(6682), true, null },
                    { new Guid("ad663ab9-961e-453c-89f6-a6d368423097"), new Guid("fd90ee79-6fa6-40ff-87da-30bdd6b9f064"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(5926), true, null },
                    { new Guid("1fe10cde-3ad6-4995-888b-18e4ff3f0bba"), new Guid("4edaa115-266c-43d8-8005-a5ee1abed2cf"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(5168), true, null },
                    { new Guid("96ee285e-78a6-4d61-9b41-7de1c15b47dc"), new Guid("6ceef0fb-9da6-42a4-b23e-5a1d32abbb59"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(4371), true, null },
                    { new Guid("c3253f25-1310-44b5-b2e9-13553f005995"), new Guid("c3c9670e-53af-4935-8951-c986aad21b6a"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(3604), true, null },
                    { new Guid("a9765975-2f58-4489-be32-065ca6c01019"), new Guid("cfdea2bf-c57e-4545-99a3-ebd7dec888ef"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(2840), true, null },
                    { new Guid("3235c9ab-c613-4136-b602-f8bcb6fda51e"), new Guid("2b1124af-bc6b-4a88-9089-0b0f513c495c"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(2026), true, null },
                    { new Guid("2b7140e8-86f1-4602-95a1-2335fa3e3cc9"), new Guid("4ed920d3-dd38-44e1-8c81-ad92e215585a"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(1257), true, null },
                    { new Guid("54a0644c-9fac-4bdb-944c-d1f55e638cdc"), new Guid("c91e0338-46be-4b35-b9cd-c544cb01f9fa"), new DateTime(2019, 6, 8, 8, 34, 33, 651, DateTimeKind.Utc).AddTicks(464), true, null },
                    { new Guid("0c201103-a52f-4e2c-b235-fb553e0b3942"), new Guid("4398a5ea-4f57-405d-867a-9e2bb1192c6b"), new DateTime(2019, 6, 8, 8, 34, 33, 650, DateTimeKind.Utc).AddTicks(9626), true, null },
                    { new Guid("71ffe75c-9832-4f6c-8c26-cb7343c8bc15"), new Guid("2c1d770a-57da-424a-9df8-d85851311db3"), new DateTime(2019, 6, 8, 8, 34, 33, 650, DateTimeKind.Utc).AddTicks(8722), true, null },
                    { new Guid("c59dbf6f-9378-4bad-9196-d8051cc5a6bf"), new Guid("42a2d6b3-5926-4b53-9171-0107220e1630"), new DateTime(2019, 6, 8, 8, 34, 33, 650, DateTimeKind.Utc).AddTicks(7866), true, null },
                    { new Guid("dbcb5421-8b2e-48a7-b60f-5cecb118fc69"), new Guid("d2f2a7a5-4b94-4b72-b0ec-18a564fccccc"), new DateTime(2019, 6, 8, 8, 34, 33, 650, DateTimeKind.Utc).AddTicks(5298), true, null },
                    { new Guid("092c5d2d-0b92-44ee-9a66-2299edd4c481"), new Guid("b188fc5c-0653-451e-a597-f9af8952ed70"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(3703), true, null },
                    { new Guid("a9e9919a-b904-4a15-9896-d5272425a051"), new Guid("69af227f-e8f1-4c10-849c-551d71888bdd"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(4452), true, null },
                    { new Guid("5beb274b-0c04-4ded-8ab2-30a5ef308908"), new Guid("f3552e30-9ea3-4286-ab65-c0e72bca2348"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(5201), true, null },
                    { new Guid("a88e13f6-b13f-4919-8ba1-2c09ff303180"), new Guid("10439b59-147d-433f-ab6c-6794ebdb9ffa"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(5971), true, null },
                    { new Guid("aa78c2b1-ff9c-447f-a415-fb80cddac6b4"), new Guid("1eb79abb-84bc-41c8-9978-92cae1f2b6d2"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(3673), true, null },
                    { new Guid("3c1f3acc-01cf-4a28-aa77-90df94a6598d"), new Guid("12b70183-6634-419f-9fe8-4e9982bf84c4"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(2897), true, null },
                    { new Guid("bdb95e44-52b3-4437-8e7a-6f2d9d1be9fd"), new Guid("1fa60ef2-2d80-468e-88ed-f1ba3c8bfe96"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(2153), true, null },
                    { new Guid("53d6fb26-8e37-4665-b089-a28597c94751"), new Guid("968a4281-a54e-4397-8304-5ad1c471590e"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(1397), true, null },
                    { new Guid("65bbc04c-242f-471a-8d40-c5bdeb9aee1c"), new Guid("c9d92c74-07be-4ab4-9e8e-6293bfb4c530"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(623), true, null },
                    { new Guid("591c3e46-be08-44f2-9722-c295cc9d8591"), new Guid("1a6ef266-ab6f-4a01-966f-a19f26486bc8"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(9873), true, null },
                    { new Guid("ba6cf67f-2621-4292-97c6-adb6677f6c9c"), new Guid("ef8eb060-d1a6-4b66-a4ca-638977527a15"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(9060), true, null },
                    { new Guid("f8c165f6-cced-46c7-b976-df3a6e4c0c24"), new Guid("0dcaf98a-fd3e-4112-9fda-3fa7da1ad290"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(8215), true, null },
                    { new Guid("bbd80bd0-356c-4da8-871f-e985b064bad0"), new Guid("4dfe104a-e281-4c4f-b4cb-cb5880e055c0"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(7464), true, null },
                    { new Guid("792b499c-12c8-4097-87a7-9daf21f9c850"), new Guid("2c279d1c-5583-4b37-a57a-ee353eca4209"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(6679), true, null },
                    { new Guid("ae77969b-1abb-4015-8229-38f6d4c7f4bc"), new Guid("e0403ce3-cf8d-48d3-8a21-0af39c40ddee"), new DateTime(2019, 6, 8, 8, 34, 33, 654, DateTimeKind.Utc).AddTicks(5176), true, null },
                    { new Guid("fa56cdca-9686-4b65-b2b7-4cd17f049178"), new Guid("c4645bbe-a6ea-4788-b018-b5012deb5910"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(5933), true, null },
                    { new Guid("7419ba70-98a2-4f99-9a4e-a2784d865197"), new Guid("5032feb1-d204-4748-a275-b2b171e0e28f"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(4397), true, null },
                    { new Guid("4951197e-4bbd-43df-938f-ed51d9e0a155"), new Guid("5f72d5b6-0387-451b-b897-e1d97a4d899a"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(3655), true, null },
                    { new Guid("2e78c55e-93ac-4c85-9e15-966d4e7f60de"), new Guid("f76c4cb2-4233-42c9-9e86-cb77b8e80498"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(2905), true, null },
                    { new Guid("943e1552-1a57-49cb-8a25-e0c8307d14e7"), new Guid("7f2de31f-b45c-42e3-9169-e540e632ec09"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(2133), true, null },
                    { new Guid("24e59514-5d0f-4361-b91d-40bbe3d75161"), new Guid("ec0ca3b9-e69f-48c9-94bc-289fcad8288b"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(625), true, null },
                    { new Guid("c5943fc7-0fa2-4fa2-b190-8bf5930cd3f0"), new Guid("7c0c8cd3-d692-459d-957e-c38ce2a168fa"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(9837), true, null },
                    { new Guid("baac6e9a-c4ed-4505-9ba6-26c84b3ddc58"), new Guid("3824d42b-f808-47ec-b2a2-93d9c4e7840c"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(9074), true, null },
                    { new Guid("e84b6e4d-5255-42fd-ae73-96255baaa720"), new Guid("0349d2ec-9650-41d2-acac-1202f44611b9"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(8243), true, null },
                    { new Guid("526cf57b-827c-4c97-baea-7ddf4bdea1cc"), new Guid("f486622b-f81b-4be5-b6b3-c6b88f8f36f3"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(7471), true, null },
                    { new Guid("c9a7a661-f78f-468a-adf7-bb9d174ad2e6"), new Guid("7a485726-06cf-4e0f-a501-0d310bcb17b8"), new DateTime(2019, 6, 8, 8, 34, 33, 652, DateTimeKind.Utc).AddTicks(6726), true, null },
                    { new Guid("75b79c13-fd6e-413c-9bc7-058f637dd5d7"), new Guid("6587d819-c4e5-47a5-b734-15c9b65b0c75"), new DateTime(2019, 6, 8, 8, 34, 33, 653, DateTimeKind.Utc).AddTicks(5184), true, null },
                    { new Guid("f2f72562-5a05-4ecb-8568-a12cffc4827f"), new Guid("1fc5ad0e-91cf-4fcd-afcc-73a51bd94905"), new DateTime(2019, 6, 8, 8, 34, 33, 656, DateTimeKind.Utc).AddTicks(5299), true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_ProductId",
                table: "CartProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number",
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFiles_FileId",
                table: "ProductFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true,
                filter: "[Sku] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProducts");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductFiles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
