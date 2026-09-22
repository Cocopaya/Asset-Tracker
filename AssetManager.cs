using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Asset_Tracker
{
    internal class AssetManager
    {
        //Add an asset to the list by filling out options
        public Asset AddAsset()
        {
            Console.WriteLine("Select asset type:");
            Console.WriteLine("1. Computer");
            Console.WriteLine("2. Mobile Phone");
            Console.WriteLine("3. Tablet");
            Console.Write("Enter your choice: ");
            string assetTypeChoice = Console.ReadLine() ?? "";
            Console.WriteLine("Enter office: ");
            Console.WriteLine("1. Sweden");
            Console.WriteLine("2. Norway");
            Console.WriteLine("3. Denmark");
            string officeChoice = Console.ReadLine() ?? "";
            Console.Write("Enter brand: ");
            string brand = Console.ReadLine() ?? "";
            Console.Write("Enter model: ");
            string model = Console.ReadLine() ?? "";
            Console.Write("Enter price: ");
            int price = int.Parse(Console.ReadLine() ?? "0");
            Asset.OfficeLocation office = Asset.OfficeLocation.Sweden; // Default value

            switch (officeChoice)
            {
                case "1":
                    office = Asset.OfficeLocation.Sweden;
                    break;
                case "2":
                    office = Asset.OfficeLocation.Norway;
                    break;
                case "3":
                    office = Asset.OfficeLocation.Denmark;
                    break;
            }
            switch (assetTypeChoice)
            {
                case "1":
                    return new Computer(office, brand, model, price, DateTime.Now);
                case "2":
                    return new MobilePhone(office, brand, model, price, DateTime.Now);
                case "3":
                    return new Tablet(office, brand, model, price, DateTime.Now);
                default:
                    Console.WriteLine("Invalid choice. Asset not added.");
                    return null;
            }
        }
        //Show assets in a table format
        public void ShowAssets(List<Asset> assets)
        {
            Console.WriteLine("ASSET LIST");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Office".PadRight(15) + "Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Price".PadRight(15) + "Purchase Date".PadRight(20) + "Status");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");


            foreach (Asset asset in assets)
            {
                string priceText = $"{asset.LocalPrice} {asset.CurrencyCode}";

                Console.Write(asset.Office.ToString().PadRight(15) + asset.GetTypeName().PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + priceText.PadRight(15) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(20));

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

        }
        //Return a sorted list of assets
        public List<Asset> SortAssets(List<Asset> assets)
        {
            Console.WriteLine("Sort assets by:");
            Console.Write("1. Asset Type\n2. Purchase Date\nChoose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    return assets.OrderBy(a => a.GetTypeName()).ToList();
                case "2":
                    return assets.OrderBy(a => a.PurchaseDate).ToList();
                default:
                    Console.WriteLine("Invalid choice. Returning unsorted list.");
                    return assets;
            }
        }
    }
}
