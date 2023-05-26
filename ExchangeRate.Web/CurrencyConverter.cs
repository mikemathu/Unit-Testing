namespace ExchangeRate.Web
{
    public class CurrencyConverter
    {
        public decimal ConvertToGbp(decimal value, decimal exchangeRate, int decimalPlaces) //converts a value using the provided exchange rate and rounds it.
        {
            if (exchangeRate <= 0) //Guard clause, as only positive exchange rates are valid
            {
                throw new ArgumentException("Exchange rate must be greater than zero",nameof(exchangeRate));
            }
            var valueInGbp = value / exchangeRate;//converts the value
            return decimal.Round(valueInGbp, decimalPlaces); //rounds the results and rounds it
        }
    }
}