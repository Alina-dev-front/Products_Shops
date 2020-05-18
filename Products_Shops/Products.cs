using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Products_Shops
{
    public class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Producers Producer { get; set; }
        public Shops Shop { get; set; }

        public override string ToString()
        {
            return $"Name : {Name} Price : {Price} Producer : {Producer} Shop: {Shop}";
        }

        public void Demo()
        {
            var producer1 = new Producers() { ProducerId = 0, ProducerName = "Arla" };
            var producer2 = new Producers() { ProducerId = 1, ProducerName = "GoodFood" };
            var producer3 = new Producers() { ProducerId = 2, ProducerName = "Nivea" };
            var producer4 = new Producers() { ProducerId = 3, ProducerName = "Nestle" };

            var products = new HashSet<Products>()
            {
                new Products() {Name = "Apple", Price = 32, Producer = producer2},
                new Products() {Name = "Milk", Price = 12, Producer = producer1},
                new Products() {Name = "Lampa", Price = 120, Producer = producer3},
                new Products() {Name = "Ketchup", Price = 8, Producer = producer4},
                new Products() {Name = "Bread", Price = 24, Producer = producer2},
                new Products() {Name = "Washing Powder", Price = 37, Producer = producer3},
                new Products() {Name = "Maple Syrop", Price = 81, Producer = producer4},
                new Products() {Name = "Kefir", Price = 17, Producer = producer1},
            };

            var listProducerArla = products.Where(s => s.Producer.ProducerId == 0);
            foreach (var product in listProducerArla)
            {
                Console.WriteLine(product.Name);
            }

            var brands = products.GroupBy(s => s.Producer)
                .Select(brand => new
                {
                    BrandName = brand.Key.ProducerName,
                    ProductCount = brand.Count()
                }).OrderBy(x => x.BrandName);
            foreach (var brand in brands)
            {
                Console.WriteLine(brand.BrandName + "\t" + brand.ProductCount);
            }
        }
    }
}
