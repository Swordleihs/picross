using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View
{
    public class IsSatisfiedConverter : IValueConverter
    {
        public Object Satisfied { get; set; }
        public Object NotSatisfied { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsSatisfied = (bool)value;

            return IsSatisfied ? Satisfied : NotSatisfied;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
