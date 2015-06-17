using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace test5_ui
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void toUrlBtn_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(urlInput.Text)==false)
            {
                wb.Navigate(new Uri(urlInput.Text));
            }
        }

        private void wb_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            statuTxt.Text = "导航失败";
        }

        private void wb_Navigating(object sender, NavigatingEventArgs e)
        {
            statuTxt.Text = "正在加载";

        }

        private void wb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            statuTxt.Text = "加载完毕";
        }

    }
}