using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_Barroc_Intens.Converters
{
    public class TrueToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value is bool boolValue && boolValue is true
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
