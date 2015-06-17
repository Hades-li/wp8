using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using homework1.Resources;

namespace homework1
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Boolean isNewPage = false;
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            isNewPage = true;

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if(!String.IsNullOrEmpty(tb1.Text))
            {
                State["txt1"] = tb1.Text;
            }
            if (!String.IsNullOrEmpty(tb2.Text))
            {
                State["txt2"] = tb2.Text;
            }
            if (!String.IsNullOrEmpty(tb3.Text))
            {
                State["txt3"] = tb3.Text;
            }
            if (!String.IsNullOrEmpty(tb4.Text))
            {
                State["txt4"] = tb4.Text;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //处理逻辑删除恢复
            if(isNewPage)
            {
                if (State.ContainsKey("txt1"))
                {
                    tb1.Text = State["txt1"] as String;
                }
                if (State.ContainsKey("txt2"))
                {
                    tb2.Text = State["txt2"] as String;
                }
                if (State.ContainsKey("txt3"))
                {
                    tb3.Text = State["txt3"] as String;
                }
                if (State.ContainsKey("txt4"))
                {
                    tb4.Text = State["txt4"] as String;
                }
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (tb1.Text == "" || tb2.Text == "" || tb3.Text == ""||tb4.Text == "")
            {
                return;
            }
            else
            {
                string mapUri = String.Format("/second/{0}/{1}/{2}/{3}",tb1.Text,tb2.Text,tb3.Text,tb4.Text);
                this.NavigationService.Navigate(new Uri(mapUri, UriKind.Relative));
            }
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
    }
}