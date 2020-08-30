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
            //TODO: implement actual conversion based on injested currency list
            return value;
        }
    }
}
