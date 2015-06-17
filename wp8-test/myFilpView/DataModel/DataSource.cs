using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace myFilpView.DataModel
{
    public class Item
    {
        private String _path;
        public String Path
        {
            get { return _path;}
            set { _path = value; }
        }
        private String _title;
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value;}                
        }

        public Item(String path,String title,int id)
        {
            this._path = path;
            this._title = title;
            this._id =id;
        }
    }
    class DataSource
    {
        public String Base_path = "Assets/imgs/";
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items;}
            set { _items = value; }
        }

        public DataSource()
        {
            InitItems();
        }
        //初始化items
        public void InitItems()
        {
            Items.Add(new Item(Base_path + "cliff.jpg", "图片1", 0));
            Items.Add(new Item(Base_path + "grapes.jpg", "图片2", 1));
            Items.Add(new Item(Base_path + "rainier.jpg", "图片3", 2));
            Items.Add(new Item(Base_path + "sunset.jpg", "图片4", 3));
            Items.Add(new Item(Base_path + "valley.jpg", "图片5", 4));
            Items.Add(new Item(Base_path + "waterfall.jpg", "图片6", 5));

        }
    }
}
