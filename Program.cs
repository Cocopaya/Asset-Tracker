using Asset_Tracker;

List<Asset> assets = new List<Asset>();

Asset assetOne = new Asset(
    Asset.OfficeLocation.Sweden,
    "Laptop",
    "Dell",
    "XPS 13",
    15000,
    new DateTime(2026, 1, 15)
);
Asset assetTwo = new Asset(
    Asset.OfficeLocation.Denmark,
    "Desktop",
    "HP",
    "Pavilion",
    20000,
    new DateTime(2026, 6, 15)
);
Asset assetThree = new Asset(
    Asset.OfficeLocation.Denmark,
    "Phone",
    "Apple",
    "iPhone 12",
    30000,
    new DateTime(2024, 2, 1)
);
Asset assetFour = new Asset(
    Asset.OfficeLocation.Norway,
    "Phone",
    "Apple",
    "iPhone 9",
    30000,
    new DateTime(2021, 8, 16)
);

assets.Add(assetOne);
assets.Add(assetTwo);
assets.Add(assetThree);
assets.Add(assetFour);

Console.WriteLine("ASSET LIST");
Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
Console.WriteLine("Office".PadRight(15) + "Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Price".PadRight(15) + "Purchase Date".PadRight(20) + "Status");
Console.WriteLine("---------------------------------------------------------------------------------------------------------------");

static string GetCurrencyCode(Asset.OfficeLocation office)
{
    return office switch
    {
        Asset.OfficeLocation.Sweden => "SEK",
        Asset.OfficeLocation.Denmark => "DKK",
        Asset.OfficeLocation.Norway => "NOK",
        _ => ""
    };
}

foreach (Asset asset in assets)
{
    string priceText = $"{asset.LocalPrice} {GetCurrencyCode(asset.Office)}";

    Console.Write(asset.Office.ToString().PadRight(15) + asset.Type.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + priceText.PadRight(15) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(20));

    string statusText = asset.ConditionStatus.ToString();

    switch (asset.ConditionStatus)
    {
        case Asset.Status.Yellow:
            Console.ForegroundColor = ConsoleColor.Yellow;
            break;
        case Asset.Status.Red:
            Console.ForegroundColor = ConsoleColor.Red;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.White;
            statusText = "";
            break;
    }

    Console.WriteLine(statusText);
    Console.ResetColor();
}

Console.ReadLine();
