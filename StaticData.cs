using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracker
{
    internal class StaticData
    {
        public static List<Asset> GetAssets()
        {
            return new List<Asset>
        {
            new Computer(Asset.OfficeLocation.Sweden, "Dell", "XPS 13", 15000, new DateTime(2026, 1, 15)),
            new Computer(Asset.OfficeLocation.Denmark, "HP", "Pavilion", 20000, new DateTime(2026, 6, 15)),
            new MobilePhone(Asset.OfficeLocation.Denmark, "Apple", "iPhone 12", 30000, new DateTime(2024, 2, 1)),
            new MobilePhone(Asset.OfficeLocation.Norway, "Apple", "iPhone 9", 30000, new DateTime(2021, 8, 16)),
        };
        }
    }
}
