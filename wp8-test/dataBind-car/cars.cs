using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataBind_car
{
    //数据模型
    public class car
    {
        public int ID {get;set;}
        public string Make { get; set; }
        public string Mode { get; set; }
        public string checkInDateTime { get; set; }
    }

    //数据源
    public class carDataSoures
    {
        private static ObservableCollection<car> _cars = new ObservableCollection<car>();
        public static ObservableCollection<car> getCars()
        {
            if(_cars.Count == 0)
            {
                _cars.Add(new car(){ ID = 0,Make = "大众",Mode = "帕萨特"});
                _cars.Add(new car(){ ID = 0,Make = "现代",Mode = "伊兰特"});
                _cars.Add(new car(){ ID = 0,Make = "宝马",Mode = "X6"});
            }
            return _cars;
        }
    }
}
