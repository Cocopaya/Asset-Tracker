using Asset_Tracker;

List<Asset> assets = StaticData.GetAssets();
AssetManager assetManager = new AssetManager();

bool exit = false;

while (!exit)
{
    Console.WriteLine("Welcome! What do you want to do?");
    Console.Write("1. Add asset\n2. Show assets\n3. Sort assets\n4. Search assets\n5. Exit\nChoose an option: ");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            Asset asset = assetManager.AddAsset();
            assets.Add(asset);
            assetManager.ShowAssets(assets);
            break;
        case "2":
            assetManager.ShowAssets(assets);
            break;
        case "3":
            List<Asset> sortedList = assetManager.SortAssets(assets);
            assetManager.ShowAssets(sortedList);
            break;
        case "4":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    if (exit) break;

    Console.Write("(Press Enter to continue)...");
    Console.ReadLine();
}
