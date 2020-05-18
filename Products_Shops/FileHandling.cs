using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace Products_Shops
{
    class FileHandling
    {
        public void Run()
        {
            var path = GetUserHomePath();

            var programPath = Path.Combine(path, ".DemoApp2020");

            if(!Directory.Exists(programPath))
            {
                Directory.CreateDirectory(programPath);
            }

            var filePath = Path.Combine(programPath, "File.txt");
            Console.WriteLine(filePath);
            ReadTextFileAndPrintToConsole(filePath);
            AppendLineToTextFile(filePath, Environment.NewLine + "New text");
        }

        

        public string GetUserHomePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile, Environment.SpecialFolderOption.DoNotVerify);
        }

        public void ReadTextFileAndPrintToConsole(string filePath)
        {
            bool test = File.Exists(filePath);
            if (File.Exists(filePath))
            {
                var lines = File.ReadLines(filePath);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void AppendLineToTextFile(string filePath, string text)
        {
            File.AppendAllText(filePath, text);
            /*File.WriteAllText = откроет файл, перезапишет текст и закроет файл*/
        }
    }
}

