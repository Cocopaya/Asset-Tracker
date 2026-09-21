using System;
using System.Collections.Generic;
using System.Text;

namespace Asset_Tracker
{
    internal class Computer : Asset
    {
        public Computer(OfficeLocation office, string brand, string model, int price, DateTime purchaseDate)
            : base(office, brand, model, price, purchaseDate)
        {
        }
        public override string GetTypeName()
        {
            return "Computer";
        }
    }
}
