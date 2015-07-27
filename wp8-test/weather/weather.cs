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

namespace weather
{
    public class Day
    {
        public string date { get; set; }
        public string temp { get; set; }
        public string weather { get; set; }
        public string wind { get; set; }
        public string fl { get; set; }
        public string img_0 { get; set; }
        public string img_1 { get; set; }
    }

    public class Weather
    {
        //每天的天气数据
        public int statues {get;set;}
        public string message {get;set;}
        public string city {get;set;}
        public ObservableCollection<Day> days{get;set;}

        public Weather()
        {
            days = new ObservableCollection<Day>();
        }

    }
    public class dataSource
    {
        //本地读取json
        public async Task<string> LoadJSON(string filePath)
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
        public async Task<string> HttpLoadJSON(string url)
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
            string weatherJson = await LoadJSON("ms-appx:///json/weather.json");
            //string weatherJson = await HttpLoadJSON(httpUrl);
            if (weatherJson != "load false")
            {
                
                JsonObject jo = JsonObject.Parse(weatherJson);
                Weather weather = new Weather();//创建weather
                weather.statues = (int)jo.GetNamedNumber("status");
                weather.message = jo.GetNamedString("message");
                JsonObject jsData = jo.GetNamedObject("data");
                weather.city = jsData.GetNamedString("city");
                Debug.WriteLine("数据读取状态:" + weather.statues);
                Debug.WriteLine("数据信息:" + weather.message);
                Debug.WriteLine("城市:" + weather.city);

                //循环获取6天的天气
                if (weather.statues == 200)
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        Day day = new Day();
                        day.date = jsData.GetNamedString("date_" + i);
                        day.temp = jsData.GetNamedString("temp_" + i);
                        day.weather = jsData.GetNamedString("weather_" + i);
                        day.wind = jsData.GetNamedString("wind_" + i);
                        day.fl = jsData.GetNamedString("fl_" + i);
                        day.img_0 = jsData.GetNamedString("img_" + (2 * i - 1));
                        day.img_1 = jsData.GetNamedString("img_" + (2 * i));
                        Debug.WriteLine("第" + i + "天");
                        Debug.WriteLine("日期：" + day.date);
                        Debug.WriteLine("温度：" + day.temp);
                        Debug.WriteLine("气候：" + day.weather);
                        Debug.WriteLine("风状况：" + day.wind);
                        Debug.WriteLine("风力：" + day.fl);
                        Debug.WriteLine("图片1：" + day.img_0);
                        Debug.WriteLine("图片2：" + day.img_1);
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
