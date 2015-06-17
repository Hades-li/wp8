using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using test5_ui.Resources;

namespace test5_ui
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            //屏幕翻转事件注册
            OrientationChanged += new EventHandler<OrientationChangedEventArgs>(oriChange);
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        
        
        // 用于生成本地化 ApplicationBar 的示例代码
        //private void BuildLocalizedApplicationBar()
        //{
        //    // 将页面的 ApplicationBar 设置为 ApplicationBar 的新实例。
        //    ApplicationBar = new ApplicationBar();

        //    // 创建新按钮并将文本值设置为 AppResources 中的本地化字符串。
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // 使用 AppResources 中的本地化字符串创建新菜单项。
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void oriChange(object sender,OrientationChangedEventArgs e)
        {
            if(e.Orientation == PageOrientation.Landscape||e.Orientation == PageOrientation.LandscapeLeft||e.Orientation == PageOrientation.LandscapeRight)
            {
                this.checkPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
            }
            else{
                this.checkPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
            }
        }
        private void myClick(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            String str = btn.Name.ToString();
            switch(str)
            {
                case "submit":
                    List<String> list = new List<string>();
                    if(cbk1.IsChecked.HasValue && cbk1.IsChecked.Value == true)
                    {
                        list.Add(cbk1.Content.ToString());
                    }
                    if (cbk2.IsChecked.HasValue && cbk2.IsChecked.Value == true)
                    {
                        list.Add(cbk2.Content.ToString());
                    }
                    if (cbk3.IsChecked.HasValue && cbk3.IsChecked.Value == true)
                    {
                        list.Add(cbk3.Content.ToString());
                    }
                    String outStr = string.Join(",", list);
                    MessageBoxResult res =  MessageBox.Show("你喜欢的蔬菜是:" + outStr,"提示",MessageBoxButton.OKCancel);
                    switch(res)
                    {
                        case MessageBoxResult.OK:
                            cbk1.Content = "你选择了";
                            break;
                        case MessageBoxResult.Cancel:
                            cbk1.Content = "你妹选择";
                            break;
                    }
                    break;
            }
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            RepeatButton rBtn = e.OriginalSource as RepeatButton;
            String str = rBtn.Name.ToString();
            if(int.TryParse(rTbNum.Text,out num))
            {
                
                switch(str)
                {
                    case "rBtnDes":
                        num--;
                        rTbNum.Text = num.ToString();
                        break;
                    case "rBtnAdd":
                        num++;
                        rTbNum.Text = num.ToString();
                        break;
                }
            }            
        }
    }
}