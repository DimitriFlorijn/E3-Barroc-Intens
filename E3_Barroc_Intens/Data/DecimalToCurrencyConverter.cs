using Microsoft.UI.Xaml.Data;
using System;
using System.Globalization;

namespace E3_Barroc_Intens
{
    public class DecimalToCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal decimalValue)
            {
                // Toon altijd twee decimalen
                return decimalValue.ToString("F2", CultureInfo.InvariantCulture);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            // Probeer het terug te converteren naar een decimal
            if (decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            return value;
        }
    }
}
