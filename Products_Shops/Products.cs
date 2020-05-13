using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper.Configuration.Attributes;

namespace Products_Shops
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        public override string ToString()
        {
            return $"Name : {Name} Price : {Price} Producer : {Producer}";
        }
    }
}
