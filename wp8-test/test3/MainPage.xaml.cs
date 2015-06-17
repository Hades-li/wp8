using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using test3.Resources;

namespace test3
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        private Boolean isNewPage = false;
        public MainPage()
        {
            InitializeComponent();
            isNewPage = true;

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/sub/photo.xaml",UriKind.Relative));
        }



        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //MessageBox.Show("已经离开这个页面。");
            base.OnNavigatedFrom(e);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //MessageBox.Show("来到这个页面。");
            if(!String.IsNullOrEmpty((Application.Current as App).appData))
            {
                txtData.Text = (Application.Current as App).appData;//将appData的值赋予文本。
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            //MessageBox.Show("马上离开这个页面。");
            base.OnNavigatingFrom(e);
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (txtX.Text == "" || txtY.Text == "" || txtZ.Text == "")
            {
                return;
            }
            else
            {
                string mapUri = String.Format("/second/{0}/{1}/{2}", txtX.Text, txtY.Text, txtZ.Text);
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