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
using System.Net;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using uwp_demo;

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
        public string aqi { get; set; }
        public string img_0 { get; set; }
        public string img_1 { get; set; }
    }

    public class Weather : INotifyPropertyChanged
    {
        //每天的天气数据
        public string statues {get;set;}
        private string _city;
        public string city 
        { 
            get
            {
                return _city;
            }
            set 
            {
                _city = value;
                NotifyPropertyChanged("city");
                
            } 
        }
        public DateTime CurDate{get;set;}
        public ObservableCollection<Day> days{get;set;}
        public ObservableCollection<int> indexs { get; set; }

        public Weather()
        {
            days = new ObservableCollection<Day>();
            indexs = new ObservableCollection<int>();
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
        //构造函数
        public dataSource()
        {
            weather = new Weather();

        }
        //本地读取json
        public const string localUrl = "ms-appx:///json/baidu_weather.json";
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
        public const string httpUrl = "http://apis.baidu.com/apistore/weatherservice/recentweathers";
        public string param = "cityname=南京&cityid=101190101";
        //public string content = null;
        public async Task<string> HttpLoadData(string url,string param)
        {
            
            Uri uri = new Uri(url+"?"+param);
            WebRequest request  = HttpWebRequest.Create(uri);
            request.Method = "GET";
            request.Headers["apikey"] = "8f8bc6149c5570fbf9e7486a843c1196";
            WebResponse response = await request.GetResponseAsync();
            Stream s = response.GetResponseStream();
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            string StrDate = "";
            string strValue = "";
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            Debug.WriteLine(strValue);
            return strValue;
        }
        //Json数据解析
        public void parseWeather(string weatherJson)
        {
           
            if (weatherJson != null)
            {
                JsonObject jo = JsonObject.Parse(weatherJson);

                weather.statues = jo.GetNamedString("errMsg");

                JsonObject weatherJo = jo.GetNamedObject("retData");
                weather.city = weatherJo.GetNamedString("city");

                Debug.WriteLine("数据读取状态:" + weather.statues);
                Debug.WriteLine("城市:" + weather.city);


                //weather.days.Add(new Day());
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
                    day.aqi = todayJo.GetNamedString("aqi");
                    weather.days.Clear();
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
                        Debug.WriteLine("最高温度：" + day.hightemp);
                        Debug.WriteLine("最低温度：" + day.lowtemp);
                        Debug.WriteLine("气候：" + day.weather);
                        Debug.WriteLine("风向：" + day.fx);
                        Debug.WriteLine("风力：" + day.fl);
                        weather.days.Add(day);
                    }
                }
            }
        }
        //刷新数据
        int index = 0;
        public async void Resfresh()
        {
            Frame frame = Window.Current.Content as Frame;
            MainPage curPage = null;
            if (frame != null)
            {
                curPage = frame.Content as MainPage;
                curPage.on_prog(true);
            }
            
            if (index == 1)
            {
                param = "cityname=北京&cityid=101010100";
                index = 0;
            }else{
                param = "cityname=南京&cityid=101190101";
                index = 1;
            }

            string weatherJson = await HttpLoadData(httpUrl, param);

            parseWeather(weatherJson);

            curPage.on_prog(false);
        }
        
        //获得一周天气
        public Weather getWeather()
        {

            Resfresh();
            return weather;
        }

        
    }
}
