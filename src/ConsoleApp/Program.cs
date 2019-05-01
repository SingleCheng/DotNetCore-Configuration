using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "appsettings.json";
            bool option = false;
            Console.WriteLine("Build config with {0}, AddJsonFile(option: false) ...", fileName);
            var config = GenerateConfiguration("appsettings.json", option);
            PrintConfigValue(config);

            GenerateConfigurationWithoutExistFile(false);
            GenerateConfigurationWithoutExistFile(true);
        }

        private static IConfigurationRoot GenerateConfiguration(string fileName, bool option)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName, option, false);

            return builder.Build();
        }

        private static void GenerateConfigurationWithoutExistFile(bool option)
        {
            Console.WriteLine("Build config without file, AddJsonFile(option: {0}) ...", option.ToString());
            try
            {
                var config = GenerateConfiguration("appsettings.none.json", option);
                PrintConfigValue(config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Build failed \n");
            }
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