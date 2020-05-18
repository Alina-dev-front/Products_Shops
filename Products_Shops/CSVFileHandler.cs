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
    public class CSVFileHandler
    {
        public void Run()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var programPath = Path.Combine(path, ".DemoApp2020");
            var csvPath = Path.Combine(programPath, "ProductData.csv");
            Console.WriteLine(csvPath);

            var records = LoadFromCsvFile<Products>(csvPath);
            
            /*SaveToCsvFile(csvPath, products);*/
        }


        public static void SaveToCsvFile<T>(string csvPath, IEnumerable<T> records)
        {
            using var writer = new StreamWriter(csvPath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }

        public static IEnumerable<T> LoadFromCsvFile<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            var list = records.ToList();
            return list;
        }
    }
}
