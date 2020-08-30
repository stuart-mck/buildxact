using System;
using System.Linq;

namespace buildxact_supplies
{
    public interface IRepoPrinter
    {
        void PrintRepo(string displayCurrency);
    }

    public class RepoPrinter : IRepoPrinter
    {
        private readonly IRepository<SupplierEntity, string> _supplierRepository;
        private readonly ICurrencyConverter _currencyConverter;

        public RepoPrinter(IRepository<SupplierEntity, string> supplierRepository, ICurrencyConverter currencyConverter)
        {
            _supplierRepository = supplierRepository;
            _currencyConverter = currencyConverter;
        }

        public void PrintRepo(string displayCurrency)
        {
            _supplierRepository.List()
                .OrderByDescending(p => _currencyConverter.ConvertCurrency(p.UnitPrice, p.Currency, displayCurrency))
                .ToList()
                .ForEach(rec => Console.WriteLine($"{rec.ItemId},{rec.Description},{decimal.Round(_currencyConverter.ConvertCurrency(rec.UnitPrice, rec.Currency, displayCurrency),2)}"));
        }
    }
}
