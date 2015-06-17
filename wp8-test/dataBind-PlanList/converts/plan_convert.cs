using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using dataBind_PlanList.viewModel;
using System.Collections.ObjectModel;

namespace dataBind_PlanList.converts
{
    public class IsEnableBtn_convert:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //throw new NotImplementedException();
            ObservableCollection<DateTime> tempDates = (ObservableCollection<DateTime>)value;
            if (tempDates.Contains(DateTime.Today))
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ProgressBar_convert:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //throw new NotImplementedException();
            ObservableCollection<DateTime> tmpDate = (ObservableCollection<DateTime>)value;
            if (tmpDate.Count <= 10)
            {
                return tmpDate.Count*10;
            }
            else
            {
                return 100;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
