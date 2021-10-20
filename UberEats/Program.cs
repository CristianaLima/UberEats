using System;
using System.IO;
using BLL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace UberEats
{
    class Program
    {

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            Console.WriteLine("Exercise List of all persons");

            var PersonManager = new PersonManager(Configuration);

            var people = PersonManager.GetPeople();

            foreach (var m in people)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
