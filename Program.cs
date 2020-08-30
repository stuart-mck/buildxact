using buildxact_supplies;
using buildxact_supplies.Domain;
using buildxact_supplies.Domain.Supplier;
using buildxact_supplies.FileParsing;
using buildxact_supplies.Injester;
using buildxact_supplies.ListPrinter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuppliesPriceLister
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = RegisterServices();

            var service = serviceProvider.GetService<SupplierListService>();

            service.ProcessFiles(new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Imports")));

            Console.ReadLine();

        }


        public static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<SupplierListService>();
            services.AddSingleton<IFileChooser, FileChooser>();
            services.AddSingleton<IRepository<SupplierEntity, string>, SupplierRepository>();
            services.AddSingleton<IListWriter, SupplierListWriter>();
            services.AddSingleton<IFileLoader, FileLoader>();
            services.AddSingleton<ICurrencyConverter, CurrencyConverter>();
            return services.BuildServiceProvider();
        }

    }
}
