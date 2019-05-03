using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ReloadOnChange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "appsettings.json";
            Console.WriteLine("Config before edit ...");
            PrintConfigValue(GenerateConfiguration(fileName, false, true));
            Console.WriteLine("Wait for manual file edit ...");
            Console.ReadLine();
            Console.WriteLine("Config after edit ...");
            PrintConfigValue(GenerateConfiguration(fileName, false, true));
            Console.WriteLine("config reload !");
        }

        private static IConfigurationRoot GenerateConfiguration(string fileName, bool option, bool reloadOnChange)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName, option, reloadOnChange);

            return builder.Build();
        }

        private static void PrintConfigValue(IConfigurationRoot config)
        {
            Console.WriteLine("Build success");
            Console.WriteLine("'{0}' \n", config["ConnectionStrings:DefaultConnection"]);

            if (string.IsNullOrEmpty(config["ConnectionStrings:DefaultConnection"]))
                Console.WriteLine("Is Null Or Empty \n");
        }
    }
}