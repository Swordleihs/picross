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
        public object Satisfied { get; set; }
        public object NotSatisfied { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool s = (bool)value;
            Console.Write(s);
            return s ? this.Satisfied : this.NotSatisfied;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
