namespace crgolden.Api
{
    using System;

    public static class SeedProducts
    {
        public static Product[] Products => new []
        {
            // 00
            new Product(new Guid("DBCB5421-8B2E-48A7-B60F-5CECB118FC69"))
            {
                IsDownload = false,
                Name = "Chai",
                Active = true,
                QuantityPerUnit = "10 boxes x 20 bags",
                UnitPrice = 18,
                UnitsInStock = 39,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 01
            new Product(new Guid("C59DBF6F-9378-4BAD-9196-D8051CC5A6BF"))
            {
                IsDownload = false,
                Name = "Chang",
                Active = true,
                QuantityPerUnit = "24 - 12 oz bottles",
                UnitPrice = 19,
                UnitsInStock = 17,
                UnitsOnOrder = 40,
                ReorderLevel = 25
            },
            // 02
            new Product(new Guid("71FFE75C-9832-4F6C-8C26-CB7343C8BC15"))
            {
                IsDownload = false,
                Name = "Aniseed Syrup",
                Active = true,
                QuantityPerUnit = "12 - 550 ml bottles",
                UnitPrice = 10,
                UnitsInStock = 13,
                UnitsOnOrder = 70,
                ReorderLevel = 25
            },
            // 03
            new Product(new Guid("0C201103-A52F-4E2C-B235-FB553E0B3942"))
            {
                IsDownload = false,
                Name = "Chef Anton's Cajun Seasoning",
                Active = true,
                QuantityPerUnit = "48 - 6 oz jars",
                UnitPrice = 22,
                UnitsInStock = 53,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 04
            new Product(new Guid("54A0644C-9FAC-4BDB-944C-D1F55E638CDC"))
            {
                IsDownload = false,
                Name = "Chef Anton's Gumbo Mix",
                Active = false,
                QuantityPerUnit = "36 boxes",
                UnitPrice = 21.35m,
                UnitsInStock = 0,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 05
            new Product(new Guid("2B7140E8-86F1-4602-95A1-2335FA3E3CC9"))
            {
                IsDownload = false,
                Name = "Grandma's Boysenberry Spread",
                Active = true,
                QuantityPerUnit = "12 - 8 oz jars",
                UnitPrice = 25,
                UnitsInStock = 120,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 06
            new Product(new Guid("3235C9AB-C613-4136-B602-F8BCB6FDA51E"))
            {
                IsDownload = false,
                Name = "Uncle Bob's Organic Dried Pears",
                Active = true,
                QuantityPerUnit = "12 - 1 lb pkgs.",
                UnitPrice = 30,
                UnitsInStock = 15,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 07
            new Product(new Guid("A9765975-2F58-4489-BE32-065CA6C01019"))
            {
                IsDownload = false,
                Name = "Northwoods Cranberry Sauce",
                Active = true,
                QuantityPerUnit = "12 - 12 oz jars",
                UnitPrice = 40,
                UnitsInStock = 6,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 08
            new Product(new Guid("C3253F25-1310-44B5-B2E9-13553F005995"))
            {
                IsDownload = false,
                Name = "Mishi Kobe Niku",
                Active = false,
                QuantityPerUnit = "18 - 500 g pkgs.",
                UnitPrice = 97,
                UnitsInStock = 29,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 09
            new Product(new Guid("96EE285E-78A6-4D61-9B41-7DE1C15B47DC"))
            {
                IsDownload = false,
                Name = "Ikura",
                Active = true,
                QuantityPerUnit = "12 - 200 ml jars",
                UnitPrice = 31,
                UnitsInStock = 31,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 10
            new Product(new Guid("1FE10CDE-3AD6-4995-888B-18E4FF3F0BBA"))
            {
                IsDownload = false,
                Name = "Queso Cabrales",
                Active = true,
                QuantityPerUnit = "1 kg pkg.",
                UnitPrice = 21,
                UnitsInStock = 30,
                UnitsOnOrder = 30,
                ReorderLevel = 0
            },
            // 11
            new Product(new Guid("AD663AB9-961E-453C-89F6-A6D368423097"))
            {
                IsDownload = false,
                Name = "Queso Manchego La Pastora",
                Active = true,
                QuantityPerUnit = "10 - 500 g pkgs.",
                UnitPrice = 38,
                UnitsInStock = 86,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 12
            new Product(new Guid("D592C3C5-9D21-4D73-B551-E452F8B18331"))
            {
                IsDownload = false,
                Name = "Konbu",
                Active = true,
                QuantityPerUnit = "2 kg box",
                UnitPrice = 6,
                UnitsInStock = 24,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 13
            new Product(new Guid("F446CBB4-CB33-4599-94E3-C8FAEA72C178"))
            {
                IsDownload = false,
                Name = "Tofu",
                Active = true,
                QuantityPerUnit = "40 - 100 g pkgs.",
                UnitPrice = 23.25m,
                UnitsInStock = 35,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 14
            new Product(new Guid("50B5F7DA-2C36-40B0-AC7F-2B8C898F7F8B"))
            {
                IsDownload = false,
                Name = "Genen Shouyu",
                Active = true,
                QuantityPerUnit = "24 - 250 ml bottles",
                UnitPrice = 15.5m,
                UnitsInStock = 9,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 15
            new Product(new Guid("4943B208-7656-4B34-A0EE-28AF101D88CB"))
            {
                IsDownload = false,
                Name = "Pavlova",
                Active = true,
                QuantityPerUnit = "32 - 500 g boxes",
                UnitPrice = 17.45m,
                UnitsInStock = 29,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 16
            new Product(new Guid("8F981368-9384-4112-97F1-897CBB45D5D9"))
            {
                IsDownload = false,
                Name = "Alice Mutton",
                Active = false,
                QuantityPerUnit = "20 - 1 kg tins",
                UnitPrice = 39,
                UnitsInStock = 0,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 17
            new Product(new Guid("7DD0C948-18CA-46A9-A039-93CC513F8866"))
            {
                IsDownload = false,
                Name = "Carnarvon Tigers",
                Active = true,
                QuantityPerUnit = "16 kg pkg.",
                UnitPrice = 62.5m,
                UnitsInStock = 42,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 18
            new Product(new Guid("115A8153-A552-445F-A288-CA2B65505EC0"))
            {
                IsDownload = false,
                Name = "Teatime Chocolate Biscuits",
                Active = true,
                QuantityPerUnit = "10 boxes x 12 pieces",
                UnitPrice = 9.2m,
                UnitsInStock = 25,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 19
            new Product(new Guid("C2F164EB-C057-4D41-9F13-34DEEDF095A7"))
            {
                IsDownload = false,
                Name = "Sir Rodney's Marmalade",
                Active = true,
                QuantityPerUnit = "30 gift boxes",
                UnitPrice = 81,
                UnitsInStock = 40,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 20
            new Product(new Guid("E8219E12-E38B-4A42-9EE7-30383D3B10A0"))
            {
                IsDownload = false,
                Name = "Sir Rodney's Scones",
                Active = true,
                QuantityPerUnit = "24 pkgs. x 4 pieces",
                UnitPrice = 10,
                UnitsInStock = 3,
                UnitsOnOrder = 40,
                ReorderLevel = 5
            },
            // 21
            new Product(new Guid("092C5D2D-0B92-44EE-9A66-2299EDD4C481"))
            {
                IsDownload = false,
                Name = "Gustaf's Knäckebröd",
                Active = true,
                QuantityPerUnit = "24 - 500 g pkgs.",
                UnitPrice = 21,
                UnitsInStock = 104,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 22
            new Product(new Guid("A9E9919A-B904-4A15-9896-D5272425A051"))
            {
                IsDownload = false,
                Name = "Tunnbröd",
                Active = true,
                QuantityPerUnit = "12 - 250 g pkgs.",
                UnitPrice = 9,
                UnitsInStock = 61,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 23
            new Product(new Guid("5BEB274B-0C04-4DED-8AB2-30A5EF308908"))
            {
                IsDownload = false,
                Name = "Guaraná Fantástica",
                Active = false,
                QuantityPerUnit = "12 - 355 ml cans",
                UnitPrice = 4.5m,
                UnitsInStock = 20,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 24
            new Product(new Guid("A88E13F6-B13F-4919-8BA1-2C09FF303180"))
            {
                IsDownload = false,
                Name = "NuNuCa Nuß-Nougat-Creme",
                Active = true,
                QuantityPerUnit = "20 - 450 g glasses",
                UnitPrice = 14,
                UnitsInStock = 76,
                UnitsOnOrder = 0,
                ReorderLevel = 30
            },
            // 25,
            new Product(new Guid("C9A7A661-F78F-468A-ADF7-BB9D174AD2E6"))
            {
                IsDownload = false,
                Name = "Gumbär Gummibärchen",
                Active = true,
                QuantityPerUnit = "100 - 250 g bags",
                UnitPrice = 31.23m,
                UnitsInStock = 15,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 26
            new Product(new Guid("526CF57B-827C-4C97-BAEA-7DDF4BDEA1CC"))
            {
                IsDownload = false,
                Name = "Schoggi Schokolade",
                Active = true,
                QuantityPerUnit = "100 - 100 g pieces",
                UnitPrice = 43.9m,
                UnitsInStock = 49,
                UnitsOnOrder = 0,
                ReorderLevel = 30
            },
            // 27
            new Product(new Guid("E84B6E4D-5255-42FD-AE73-96255BAAA720"))
            {
                IsDownload = false,
                Name = "Rössle Sauerkraut",
                Active = false,
                QuantityPerUnit = "25 - 825 g cans",
                UnitPrice = 45.6m,
                UnitsInStock = 26,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 28
            new Product(new Guid("BAAC6E9A-C4ED-4505-9BA6-26C84B3DDC58"))
            {
                IsDownload = false,
                Name = "Thüringer Rostbratwurst",
                Active = false,
                QuantityPerUnit = "50 bags x 30 sausgs.",
                UnitPrice = 123.79m,
                UnitsInStock = 0,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 29
            new Product(new Guid("C5943FC7-0FA2-4FA2-B190-8BF5930CD3F0"))
            {
                IsDownload = false,
                Name = "Nord-Ost Matjeshering",
                Active = true,
                QuantityPerUnit = "10 - 200 g glasses",
                UnitPrice = 25.89m,
                UnitsInStock = 10,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 30
            new Product(new Guid("24E59514-5D0F-4361-B91D-40BBE3D75161"))
            {
                IsDownload = false,
                Name = "Gorgonzola Telino",
                Active = true,
                QuantityPerUnit = "12 - 100 g pkgs",
                UnitPrice = 12.5m,
                UnitsInStock = 0,
                UnitsOnOrder = 70,
                ReorderLevel = 20
            },
            // 31
            new Product(new Guid("601DD021-51C6-4FDA-9149-D885ACEEB881"))
            {
                IsDownload = false,
                Name = "Mascarpone Fabioli",
                Active = true,
                QuantityPerUnit = "24 - 200 g pkgs.",
                UnitPrice = 32,
                UnitsInStock = 9,
                UnitsOnOrder = 40,
                ReorderLevel = 25
            },
            // 32
            new Product(new Guid("943E1552-1A57-49CB-8A25-E0C8307D14E7"))
            {
                IsDownload = false,
                Name = "Geitost",
                Active = true,
                QuantityPerUnit = "500 g",
                UnitPrice = 2.5m,
                UnitsInStock = 112,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            },
            // 33
            new Product(new Guid("2E78C55E-93AC-4C85-9E15-966D4E7F60DE"))
            {
                IsDownload = false,
                Name = "Sasquatch Ale",
                Active = true,
                QuantityPerUnit = "24 - 12 oz bottles",
                UnitPrice = 14,
                UnitsInStock = 111,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 34
            new Product(new Guid("4951197E-4BBD-43DF-938F-ED51D9E0A155"))
            {
                IsDownload = false,
                Name = "Steeleye Stout",
                Active = true,
                QuantityPerUnit = "24 - 12 oz bottles",
                UnitPrice = 18,
                UnitsInStock = 20,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 35
            new Product(new Guid("7419BA70-98A2-4F99-9A4E-A2784D865197"))
            {
                IsDownload = false,
                Name = "Inlagd Sill",
                Active = true,
                QuantityPerUnit = "24 - 250 g  jars",
                UnitPrice = 19,
                UnitsInStock = 112,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            },
            // 36
            new Product(new Guid("75B79C13-FD6E-413C-9BC7-058F637DD5D7"))
            {
                IsDownload = false,
                Name = "Gravad lax",
                Active = true,
                QuantityPerUnit = "12 - 500 g pkgs.",
                UnitPrice = 26,
                UnitsInStock = 11,
                UnitsOnOrder = 50,
                ReorderLevel = 25
            },
            // 37
            new Product(new Guid("FA56CDCA-9686-4B65-B2B7-4CD17F049178"))
            {
                IsDownload = false,
                Name = "Côte de Blaye",
                Active = true,
                QuantityPerUnit = "12 - 75 cl bottles",
                UnitPrice = 263.5m,
                UnitsInStock = 17,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 38
            new Product(new Guid("792B499C-12C8-4097-87A7-9DAF21F9C850"))
            {
                IsDownload = false,
                Name = "Chartreuse verte",
                Active = true,
                QuantityPerUnit = "750 cc per bottle",
                UnitPrice = 18,
                UnitsInStock = 69,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 39
            new Product(new Guid("BBD80BD0-356C-4DA8-871F-E985B064BAD0"))
            {
                IsDownload = false,
                Name = "Boston Crab Meat",
                Active = true,
                QuantityPerUnit = "24 - 4 oz tins",
                UnitPrice = 18.4m,
                UnitsInStock = 123,
                UnitsOnOrder = 0,
                ReorderLevel = 30
            },
            // 40
            new Product(new Guid("F8C165F6-CCED-46C7-B976-DF3A6E4C0C24"))
            {
                IsDownload = false,
                Name = "Jack's New England Clam Chowder",
                Active = true,
                QuantityPerUnit = "12 - 12 oz cans",
                UnitPrice = 9.65m,
                UnitsInStock = 85,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 41
            new Product(new Guid("BA6CF67F-2621-4292-97C6-ADB6677F6C9C"))
            {
                IsDownload = false,
                Name = "Singaporean Hokkien Fried Mee",
                Active = false,
                QuantityPerUnit = "32 - 1 kg pkgs.",
                UnitPrice = 14,
                UnitsInStock = 26,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 42
            new Product(new Guid("591C3E46-BE08-44F2-9722-C295CC9D8591"))
            {
                IsDownload = false,
                Name = "Ipoh Coffee",
                Active = true,
                QuantityPerUnit = "16 - 500 g tins",
                UnitPrice = 46,
                UnitsInStock = 17,
                UnitsOnOrder = 10,
                ReorderLevel = 25
            },
            // 43
            new Product(new Guid("65BBC04C-242F-471A-8D40-C5BDEB9AEE1C"))
            {
                IsDownload = false,
                Name = "Gula Malacca",
                Active = true,
                QuantityPerUnit = "20 - 2 kg bags",
                UnitPrice = 19.45m,
                UnitsInStock = 27,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 44
            new Product(new Guid("53D6FB26-8E37-4665-B089-A28597C94751"))
            {
                IsDownload = false,
                Name = "Rogede sild",
                Active = true,
                QuantityPerUnit = "1k pkg.",
                UnitPrice = 9.5m,
                UnitsInStock = 5,
                UnitsOnOrder = 70,
                ReorderLevel = 15
            },
            // 45
            new Product(new Guid("BDB95E44-52B3-4437-8E7A-6F2D9D1BE9FD"))
            {
                IsDownload = false,
                Name = "Spegesild",
                Active = true,
                QuantityPerUnit = "4 - 450 g glasses",
                UnitPrice = 12,
                UnitsInStock = 95,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 46
            new Product(new Guid("3C1F3ACC-01CF-4A28-AA77-90DF94A6598D"))
            {
                IsDownload = false,
                Name = "Zaanse koeken",
                Active = true,
                QuantityPerUnit = "10 - 4 oz boxes",
                UnitPrice = 9.5m,
                UnitsInStock = 36,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 47
            new Product(new Guid("AA78C2B1-FF9C-447F-A415-FB80CDDAC6B4"))
            {
                IsDownload = false,
                Name = "Chocolade",
                Active = true,
                QuantityPerUnit = "10 pkgs.",
                UnitPrice = 12.75m,
                UnitsInStock = 15,
                UnitsOnOrder = 70,
                ReorderLevel = 25
            },
            // 48
            new Product(new Guid("4BDCFB51-9D36-4E9D-B43C-9A85E500E1EE"))
            {
                IsDownload = false,
                Name = "Maxilaku",
                Active = true,
                QuantityPerUnit = "24 - 50 g pkgs.",
                UnitPrice = 20,
                UnitsInStock = 10,
                UnitsOnOrder = 60,
                ReorderLevel = 15
            },
            // 49
            new Product(new Guid("AE77969B-1ABB-4015-8229-38F6D4C7F4BC"))
            {
                IsDownload = false,
                Name = "Valkoinen suklaa",
                Active = true,
                QuantityPerUnit = "12 - 100 g bars",
                UnitPrice = 16.25m,
                UnitsInStock = 65,
                UnitsOnOrder = 0,
                ReorderLevel = 30
            },
            // 50
            new Product(new Guid("76B61CAC-7040-4288-B6FF-E99D09F10962"))
            {
                IsDownload = false,
                Name = "Manjimup Dried Apples",
                Active = true,
                QuantityPerUnit = "50 - 300 g pkgs.",
                UnitPrice = 53,
                UnitsInStock = 20,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 51
            new Product(new Guid("F93A5554-5E8C-4D72-A0B8-17A29230CB98"))
            {
                IsDownload = false,
                Name = "Filo Mix",
                Active = true,
                QuantityPerUnit = "16 - 2 kg boxes",
                UnitPrice = 7,
                UnitsInStock = 38,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 52
            new Product(new Guid("D88FE2F1-8DFA-49E3-B6B6-36AD136DDB47"))
            {
                IsDownload = false,
                Name = "Perth Pasties",
                Active = false,
                QuantityPerUnit = "48 pieces",
                UnitPrice = 32.8m,
                UnitsInStock = 0,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 53
            new Product(new Guid("C0EAEA77-D109-4311-AA71-E5D2A6A4AD4D"))
            {
                IsDownload = false,
                Name = "Tourtière",
                Active = true,
                QuantityPerUnit = "16 pies",
                UnitPrice = 7.458m,
                UnitsInStock = 21,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 54
            new Product(new Guid("36F89C97-344A-4F59-AA00-9F875B6593DA"))
            {
                IsDownload = false,
                Name = "Pâté chinois",
                Active = true,
                QuantityPerUnit = "24 boxes x 2 pies",
                UnitPrice = 24,
                UnitsInStock = 115,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            },
            // 55
            new Product(new Guid("7F57B1C1-1931-4263-A1F9-0A257F1C49B8"))
            {
                IsDownload = false,
                Name = "Gnocchi di nonna Alice",
                Active = true,
                QuantityPerUnit = "24 - 250 g pkgs.",
                UnitPrice = 38,
                UnitsInStock = 21,
                UnitsOnOrder = 10,
                ReorderLevel = 30
            },
            // 56
            new Product(new Guid("88911341-95BD-434D-AB35-E7B4A599199C"))
            {
                IsDownload = false,
                Name = "Ravioli Angelo",
                Active = true,
                QuantityPerUnit = "24 - 250 g pkgs.",
                UnitPrice = 19.5m,
                UnitsInStock = 36,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            },
            // 57
            new Product(new Guid("BBF389C8-EC1B-47F4-A00E-1AD7ECA1C2EA"))
            {
                IsDownload = false,
                Name = "Escargots de Bourgogne",
                Active = true,
                QuantityPerUnit = "24 pieces",
                UnitPrice = 13.25m,
                UnitsInStock = 62,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            },
            // 58
            new Product(new Guid("FB0A5251-E0BD-49A2-B01E-8BEE844618E7"))
            {
                IsDownload = false,
                Name = "Raclette Courdavault",
                Active = true,
                QuantityPerUnit = "5 kg pkg.",
                UnitPrice = 55,
                UnitsInStock = 79,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 59
            new Product(new Guid("F68E7B31-37EC-4260-B424-E7BD550FF9E3"))
            {
                IsDownload = false,
                Name = "Camembert Pierrot",
                Active = true,
                QuantityPerUnit = "15 - 300 g rounds",
                UnitPrice = 34,
                UnitsInStock = 19,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 60
            new Product(new Guid("6B4260A2-A9EA-4587-91E5-8385996B7355"))
            {
                IsDownload = false,
                Name = "Sirop d'érable",
                Active = true,
                QuantityPerUnit = "24 - 500 ml bottles",
                UnitPrice = 28.5m,
                UnitsInStock = 113,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 61
            new Product(new Guid("E46F4C5D-363E-46BC-AC44-712E4457C2CA"))
            {
                IsDownload = false,
                Name = "Tarte au sucre",
                Active = true,
                QuantityPerUnit = "48 pies",
                UnitPrice = 49.3m,
                UnitsInStock = 17,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 62
            new Product(new Guid("E97B2E87-9B2F-4B13-99C6-0005C7732155"))
            {
                IsDownload = false,
                Name = "Vegie-spread",
                Active = true,
                QuantityPerUnit = "15 - 625 g jars",
                UnitPrice = 43.9m,
                UnitsInStock = 24,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 63
            new Product(new Guid("7B76C7EE-8FF4-4079-B46B-0EDB67270246"))
            {
                IsDownload = false,
                Name = "Wimmers gute Semmelknödel",
                Active = true,
                QuantityPerUnit = "20 bags x 4 pieces",
                UnitPrice = 33.25m,
                UnitsInStock = 22,
                UnitsOnOrder = 80,
                ReorderLevel = 30
            },
            // 64
            new Product(new Guid("3A111262-F6B1-4C2F-BC6E-A88737DC1E8C"))
            {
                IsDownload = false,
                Name = "Louisiana Fiery Hot Pepper Sauce",
                Active = true,
                QuantityPerUnit = "32 - 8 oz bottles",
                UnitPrice = 21.05m,
                UnitsInStock = 76,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 65
            new Product(new Guid("6CB52A87-0690-446C-A23B-64C43EC8F0DB"))
            {
                IsDownload = false,
                Name = "Louisiana Hot Spiced Okra",
                Active = true,
                QuantityPerUnit = "24 - 8 oz jars",
                UnitPrice = 17,
                UnitsInStock = 4,
                UnitsOnOrder = 100,
                ReorderLevel = 20
            },
            // 66
            new Product(new Guid("252F0916-6C20-4FD2-A5F4-7051881988F6"))
            {
                IsDownload = false,
                Name = "Laughing Lumberjack Lager",
                Active = true,
                QuantityPerUnit = "24 - 12 oz bottles",
                UnitPrice = 14,
                UnitsInStock = 52,
                UnitsOnOrder = 0,
                ReorderLevel = 10
            },
            // 67
            new Product(new Guid("0D2C5B7D-8C6E-4399-A18D-C45CB2A59BA8"))
            {
                IsDownload = false,
                Name = "Scottish Longbreads",
                Active = true,
                QuantityPerUnit = "10 boxes x 8 pieces",
                UnitPrice = 12.5m,
                UnitsInStock = 6,
                UnitsOnOrder = 10,
                ReorderLevel = 15
            },
            // 68
            new Product(new Guid("30F6CF4F-6D99-425A-BA31-7E23F48783B6"))
            {
                IsDownload = false,
                Name = "Gudbrandsdalsost",
                Active = true,
                QuantityPerUnit = "10 kg pkg.",
                UnitPrice = 36,
                UnitsInStock = 26,
                UnitsOnOrder = 0,
                ReorderLevel = 15
            },
            // 69
            new Product(new Guid("47E058AE-7A73-4C5E-A631-7C55B5B64C13"))
            {
                IsDownload = false,
                Name = "Outback Lager",
                Active = true,
                QuantityPerUnit = "24 - 355 ml bottles",
                UnitPrice = 15,
                UnitsInStock = 15,
                UnitsOnOrder = 10,
                ReorderLevel = 30
            },
            // 70
            new Product(new Guid("7A12B5AB-1C99-496A-AAF3-D7A8062677F3"))
            {
                IsDownload = false,
                Name = "Flotemysost",
                Active = true,
                QuantityPerUnit = "10 - 500 g pkgs.",
                UnitPrice = 21.5m,
                UnitsInStock = 26,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 71
            new Product(new Guid("28AA496E-D877-4210-AA5F-481FDCFA4238"))
            {
                IsDownload = false,
                Name = "Mozzarella di Giovanni",
                Active = true,
                QuantityPerUnit = "24 - 200 g pkgs.",
                UnitPrice = 34.8m,
                UnitsInStock = 14,
                UnitsOnOrder = 0,
                ReorderLevel = 0
            },
            // 72
            new Product(new Guid("D9B8B94C-4865-4196-9EA6-E093C27E6666"))
            {
                IsDownload = false,
                Name = "Röd Kaviar",
                Active = true,
                QuantityPerUnit = "24 - 150 g jars",
                UnitPrice = 15,
                UnitsInStock = 101,
                UnitsOnOrder = 0,
                ReorderLevel = 5
            },
            // 73
            new Product(new Guid("C5CDCB4E-CAB0-44BF-B0EF-55929C79A591"))
            {
                IsDownload = false,
                Name = "Longlife Tofu",
                Active = true,
                QuantityPerUnit = "5 kg pkg.",
                UnitPrice = 10,
                UnitsInStock = 4,
                UnitsOnOrder = 20,
                ReorderLevel = 5
            },
            // 74
            new Product(new Guid("9EB2D006-E87A-4D10-AE7F-E4EBB5E0B2E6"))
            {
                IsDownload = false,
                Name = "Rhönbräu Klosterbier",
                Active = true,
                QuantityPerUnit = "24 - 0.5 l bottles",
                UnitPrice = 7.75m,
                UnitsInStock = 125,
                UnitsOnOrder = 0,
                ReorderLevel = 25
            },
            // 75
            new Product(new Guid("F2F72562-5A05-4ECB-8568-A12CFFC4827F"))
            {
                IsDownload = false,
                Name = "Lakkalikööri",
                Active = true,
                QuantityPerUnit = "500 ml",
                UnitPrice = 18,
                UnitsInStock = 57,
                UnitsOnOrder = 0,
                ReorderLevel = 20
            }
        };
    }
}
