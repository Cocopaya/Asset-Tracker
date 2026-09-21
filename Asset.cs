using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracker
{
    internal class Asset
    {
        public Asset(OfficeLocation office, string type, string brand, string model, int price, DateTime purchaseDate)
        {
            Office = office;
            Type = type;
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = purchaseDate;
        }

        public enum Status
        {
            Green,
            Yellow,
            Red
        }

        public enum OfficeLocation
        {
            Sweden,
            Denmark,
            Norway
        }
        public OfficeLocation Office { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Status ConditionStatus => GetStatus();

        private static readonly Dictionary<OfficeLocation, double> ExchangeRates = new()
        {
            { OfficeLocation.Sweden, 1.0 },
            { OfficeLocation.Denmark, 0.68 },
            { OfficeLocation.Norway, 1.01 }
        };
        public int LocalPrice => (int)Math.Round(Price * ExchangeRates[Office]);

        public Status GetStatus()
        {
            DateTime currentDate = DateTime.Now;

            DateTime redThreshold = PurchaseDate.AddYears(3).AddMonths(-3);
            DateTime yellowThreshold = PurchaseDate.AddYears(3).AddMonths(-6);

            if (currentDate >= redThreshold)
            {
                return Status.Red;
            }
            else if (currentDate >= yellowThreshold)
            {
                return Status.Yellow;
            }
            else
            {
                return Status.Green;
            }
        }
    }
}
