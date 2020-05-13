using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Products_Shops
{
    class CSVFileHandler
    {
        public void Run()
        {
            var products = new HashSet<Product>()
            {
                new Product() {Name = "Milk", Price = 12, Producer = "Arla"},
                new Product() {Name = "Shampoo", Price = 35, Producer = "Nivea"},
                new Product() {Name = "Chocolate Bar", Price = 5, Producer = "Nestle"}
            };
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, ".DemoApp2020");
            var csvPath = Path.Combine(programPath, "Test.csv");

            var records = LoadFromCsvFile<Product>(csvPath);

            foreach (var product in records)
            {
                Console.WriteLine(product);
            }

            SaveToCsvFile(csvPath, products);
        }

        public static void SaveToCsvFile<T>(string csvPath, IEnumerable<T> records)
        {
            using var writer = new StreamWriter(csvPath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }

        public static IEnumerable<T> LoadFromCsvFile<T>(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string? item;
                do
                {
                    item = reader.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();
            }
            return records;
        }
    }
}
