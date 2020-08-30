namespace buildxact_supplies
{
    public interface ICurrencyConverter
    {
        decimal ConvertCurrency(decimal value, string sourceCurrency, string targetCurrency);
    }

    public class CurrencyConverter : ICurrencyConverter
    {
        public decimal ConvertCurrency(decimal value, string sourceCurrency, string targetCurrency)
        {
            return value;
        }
    }
}
