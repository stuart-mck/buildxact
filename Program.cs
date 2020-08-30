using buildxact_supplies;
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


        }


        public static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<SupplierListService>();
            services.AddSingleton<IFileChooser, FileChooser>();
            services.AddSingleton<IRepository<SupplierEntity, string>, SupplierRepository>();
            services.AddSingleton<IRepoPrinter, RepoPrinter>();
            services.AddSingleton<IFileLoader, FileLoader>();
            services.AddSingleton<ICurrencyConverter, CurrencyConverter>();
            return services.BuildServiceProvider();
        }

    }
}
