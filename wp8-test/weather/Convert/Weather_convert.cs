using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace weather.Convert
{
    class Week_convert : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime today = DateTime.Parse(App.ds.weather.days[0].date);
            DateTime date = DateTime.Parse(value.ToString());
            if (DateTime.Equals(today, date))
            {
                return "今天";
            }
            else
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "周日";
                    case DayOfWeek.Monday:
                        return "周一";
                    case DayOfWeek.Tuesday:
                        return "周二";
                    case DayOfWeek.Wednesday:
                        return "周三";
                    case DayOfWeek.Thursday:
                        return "周四";
                    case DayOfWeek.Friday:
                        return "周五";
                    case DayOfWeek.Saturday:
                        return "周六";
                }

            }
 	        throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
 	        throw new NotImplementedException();
        }
    }

    class Weather_convert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {

            String base_url = "ms-appx:///Assets/weather-icons/";
            String w_str = value.ToString();
            switch(w_str)
            {
                case "晴":
                    return new Uri(base_url + "sun.png");
                case "多云":
                    return new Uri(base_url + "cloud.png");
                case "晴转多云":
                    return new Uri(base_url + "sun_cloud.png");
                default:
                    return new Uri("ms-appx:///Assets/Logo.scale-240.png");
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
