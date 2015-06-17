using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;
using System.Diagnostics;
using dataBind_PlanList.commands;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace dataBind_PlanList.viewModel
{
    public class plan : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public ObservableCollection<DateTime> dates { get; set; }

        [IgnoreDataMember]
        public commandClick commandBtn { get; set; }

        public plan()
        {
            commandBtn = new commandClick();
            dates = new ObservableCollection<DateTime>();
        }

        //增加日期
        public void addDate()
        {
            dates.Add(DateTime.Today);
            Debug.WriteLine("增加的日期为：" + dates.Last());
            NotifyPropertyChanged("dates");
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
        public ObservableCollection<plan> plans;
        public dataSource()
        {
            plans = new ObservableCollection<plan>();
        }

        public async Task<ObservableCollection<plan>> getPlans()
        {
            //if (plans.Count == 0)
            //{
            //    plan temp = new plan() { ID = 0, Title = "样列", Desc = "这等于一个样列" };
            //    temp.dates = new ObservableCollection<DateTime>();
            //    temp.dates.Add(DateTime.Today);
            //    plans.Add(temp);
            //}
            if (plans.Count == 0)//判断当前的plans是否为空，如果为空就从文件读取。
            {
                await loadPlans();
            }
            return plans;
        }

        //增加一条计划
        public void addPlan(string title,string desc)
        {
            plans.Add(new plan() { ID = plans.Count + 1, Title = title, Desc = desc });
            //await savePlans();
        }

        private const string XMLFILENAME = "plans.xml";
        //读取计划表
        public async Task loadPlans()
        {
            DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(ObservableCollection<plan>));

            try
            {
                using (Stream stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(XMLFILENAME))
                {
                    plans = (ObservableCollection<plan>)xmlSerializer.ReadObject(stream);
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("读取文件报错："+e);
                plans = new ObservableCollection<plan>();
            }
        }
        //计划表保存
        public async Task savePlans()
        {
            DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(ObservableCollection<plan>));

            try
            {
                using (Stream stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(XMLFILENAME,CreationCollisionOption.ReplaceExisting))
                {
                    xmlSerializer.WriteObject(stream, plans);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("写入失败的原因：" + e);
            }
        }
    }
}
