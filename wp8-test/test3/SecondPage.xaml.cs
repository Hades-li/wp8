using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace test3
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            String x = this.NavigationContext.QueryString["x"];
            String y = this.NavigationContext.QueryString["y"];
            String z = this.NavigationContext.QueryString["z"];
            tbX.Text = x;
            tbY.Text = y;
            tbZ.Text = z;
        }
    }
}