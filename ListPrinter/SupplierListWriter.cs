using buildxact_supplies.Domain;
using buildxact_supplies.Domain.Supplier;
using System;
using System.Linq;

namespace buildxact_supplies.ListPrinter
{
    public class SupplierListWriter : IListWriter
    {
        private readonly IRepository<SupplierEntity, string> _supplierRepository;
        private readonly ICurrencyConverter _currencyConverter;

        public SupplierListWriter(IRepository<SupplierEntity, string> supplierRepository, ICurrencyConverter currencyConverter)
        {
            _supplierRepository = supplierRepository;
            _currencyConverter = currencyConverter;
        }

        public void PrintRepo(string displayCurrency)
        {
            _supplierRepository.List()
                .OrderByDescending(p => _currencyConverter.ConvertCurrency(p.UnitPrice, p.Currency, displayCurrency))
                .ToList()
                .ForEach(rec => Console.WriteLine($"{rec.ItemId},{rec.Description},{decimal.Round(_currencyConverter.ConvertCurrency(rec.UnitPrice, rec.Currency, displayCurrency), 2)}"));
        }
    }
}
