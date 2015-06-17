using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace homework1
{
    public partial class secPage : PhoneApplicationPage
    {
        public secPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            s_tb1.Text = NavigationContext.QueryString["a"];
            s_tb2.Text = NavigationContext.QueryString["b"];
            s_tb3.Text = NavigationContext.QueryString["c"];
            s_tb4.Text = NavigationContext.QueryString["d"];
        }
    }
    
}