using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using Windows.Data.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace weather
{
    public class Day
    {
        public string date { get; set; }
        public string hightemp { get; set; }
        public string lowtemp { get; set; }
        public string weather { get; set; }
        public string fx { get; set; }
        public string fl { get; set; }
        public string img_0 { get; set; }
        public string img_1 { get; set; }
    }

    public class Weather : INotifyPropertyChanged
    {
        //每天的天气数据
        public string statues {get;set;}
        //public string message {get;set;}
        public string city {get;set;}
        public DateTime CurDate{get;set;}
        public ObservableCollection<Day> days{get;set;}

        public Weather()
        {
            days = new ObservableCollection<Day>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    public class dataSource
    {
        public Weather weather = null;
        //本地读取json
        public async Task<string> LocalLoadData(string filePath)
        {
            try
            {

                Uri uri = new Uri(filePath);
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);//通过Uri读取安装包中的文件
                string jsonString = await FileIO.ReadTextAsync(file);//将json文件读取成字符串
                //Debug.WriteLine("json字符串:" + jsonString);
                return jsonString;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("报错信息:" + e);
            }

            return "load false";
        }
        //从网络读取天气的信息JSON的信息
        public async Task<string> HttpLoadData(string url)
        {
            HttpClient hc = new HttpClient();
            Uri uri = new Uri(url);
            try
            {
                string jsonString = await hc.GetStringAsync(uri);
                Debug.WriteLine("json字符串:" + jsonString);
                return jsonString;
            }
            catch (Exception e)
            {
                Debug.WriteLine("http报错信息:" + e.ToString());
                return "load false";
            }
        }

        public const string httpUrl = "http://api.36wu.com/Weather/GetMoreWeather?district=南京&format=json";
        //获得一周天气
        public async Task<Weather> getWeather()
        {
            string weatherJson = await LocalLoadData("ms-appx:///json/baidu_weather.json");
            //string weatherJson = await HttpLoadJSON(httpUrl);
            if (weatherJson != "load false")
            {
                weather = new Weather();//创建weather
                JsonObject jo = JsonObject.Parse(weatherJson);

                weather.statues = jo.GetNamedString("errMsg");

                JsonObject weatherJo = jo.GetNamedObject("retData");
                weather.city = weatherJo.GetNamedString("city");
               
                
                Debug.WriteLine("数据读取状态:" + weather.statues);
                Debug.WriteLine("城市:" + weather.city);

                
                if (weather.statues == "success")
                {

                    //获取今天的气候
                    JsonObject todayJo = weatherJo.GetNamedObject("today");
                    Day day = new Day();
                    day.date = todayJo.GetNamedString("date");
                    day.hightemp = todayJo.GetNamedString("hightemp");
                    day.lowtemp = todayJo.GetNamedString("lowtemp");
                    day.weather = todayJo.GetNamedString("type");
                    day.fl = todayJo.GetNamedString("fengli");
                    day.fx = todayJo.GetNamedString("fengxiang");
                    weather.days.Add(day);
                    JsonArray ja = weatherJo.GetNamedArray("forecast");

                    //循环获取未来5天的天气
                    for (int i = 0; i < ja.Count; i++)
                    {
                        day = new Day();
                        day.date = ja[i].GetObject().GetNamedString("date");
                        day.hightemp = ja[i].GetObject().GetNamedString("hightemp");
                        day.lowtemp = ja[i].GetObject().GetNamedString("lowtemp");
                        day.weather = ja[i].GetObject().GetNamedString("type");
                        day.fl = ja[i].GetObject().GetNamedString("fengli");
                        day.fx = ja[i].GetObject().GetNamedString("fengxiang");
                       
                        Debug.WriteLine("第" + i + "天");
                        Debug.WriteLine("日期(prase)：" + DateTime.Parse(day.date));
                        Debug.WriteLine("温度：" + day.hightemp);
                        Debug.WriteLine("温度：" + day.lowtemp);
                        Debug.WriteLine("气候：" + day.weather);
                        Debug.WriteLine("风向：" + day.fx);
                        Debug.WriteLine("风力：" + day.fl);
                        weather.days.Add(day);
                    }
                    return weather;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
