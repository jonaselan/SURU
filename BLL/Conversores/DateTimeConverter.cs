using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BLL.Conversores
{
    public class DateTimeConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                throw new NullReferenceException("value can not be null");
            }
            DateTime date = (DateTime)value;
            string strDate = date.ToLongDateString();

            if (date.Date == DateTime.Today.Date)
            {
                strDate = "Hoje";
            }else if(date.Date == DateTime.Today.Date.AddDays(-1))
            {
                strDate = "Ontem";
            }

            return strDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
