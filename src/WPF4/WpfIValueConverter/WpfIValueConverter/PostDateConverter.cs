using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfIValueConverter
{
    //[1] 
    public class PostDateConverter : IValueConverter
    {
        // 코드단 -> 가공(Converter) -> UI단
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // parameter가 있으면 적용
            if (parameter != null)
            {
                return String.Format(parameter.ToString(), value); // 년 월 일
            }
            return String.Format("{0:yyyy-MM-dd}", value); // - - 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
