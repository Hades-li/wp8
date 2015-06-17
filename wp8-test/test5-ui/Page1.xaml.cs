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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        //移动方块
        private void Rectangle_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            myTT.X += e.DeltaManipulation.Translation.X;
            myTT.Y += e.DeltaManipulation.Translation.Y;
        }
        //触发进度条增加
        private void pgBtn_Click(object sender, RoutedEventArgs e)
        {
            mySB.Begin();
            myPgTxt.Visibility = Visibility.Visible;
        }

        private void mySB_Completed(object sender, EventArgs e)
        {
            myPgTxt.Visibility = Visibility.Collapsed;
        }
    }
}