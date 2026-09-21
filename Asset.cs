// Asset.cs
using System;
using System.Collections.Generic;

namespace Asset_Tracker
{
    internal class Asset
    {
        public enum Status { Green, Yellow, Red }
        public enum OfficeLocation { Sweden, Denmark, Norway }

        private static readonly Dictionary<OfficeLocation, double> ExchangeRates = new()
        {
            { OfficeLocation.Sweden, 1.0 },
            { OfficeLocation.Denmark, 0.68 },
            { OfficeLocation.Norway, 1.01 }
        };

        private static readonly Dictionary<OfficeLocation, string> CurrencyCodes = new()
        {
            { OfficeLocation.Sweden, "SEK" },
            { OfficeLocation.Denmark, "DKK" },
            { OfficeLocation.Norway, "NOK" }
        };

        public Asset(OfficeLocation office, string brand, string model, int price, DateTime purchaseDate)
        {
            Office = office;
            Brand = brand;
            Model = model;
            Price = price;
            PurchaseDate = purchaseDate;
        }

        public OfficeLocation Office { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Status ConditionStatus => GetStatus();
        public int LocalPrice => (int)Math.Round(Price * ExchangeRates[Office]);
        public string CurrencyCode => CurrencyCodes[Office];

        public Status GetStatus()
        {
            DateTime currentDate = DateTime.Now;
            DateTime redThreshold = PurchaseDate.AddYears(3).AddMonths(-3);
            DateTime yellowThreshold = PurchaseDate.AddYears(3).AddMonths(-6);

            if (currentDate >= redThreshold) return Status.Red;
            if (currentDate >= yellowThreshold) return Status.Yellow;
            return Status.Green;
        }

        // virtual = subklasser FÅR (men måste inte) skriva över denna
        public virtual string GetTypeName()
        {
            return "Asset";
        }
    }
}