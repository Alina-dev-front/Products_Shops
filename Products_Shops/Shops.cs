using System;
using System.Collections.Generic;
using System.Linq;

namespace Products_Shops
{
    public class Shops
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }

        public void ShopObj()
        {
            var shop1 = new Shops() { ShopId = 1, ShopName = "Ica" };
            var shop2 = new Shops() { ShopId = 2, ShopName = "Coop" };
            var shop3 = new Shops() { ShopId = 3, ShopName = "Metro" };
        }
    }
}
