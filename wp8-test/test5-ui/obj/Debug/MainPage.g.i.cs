﻿#pragma checksum "D:\developSpace\wp8Space\wp8-test\test5-ui\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4636E119E8995B42249AB7006C2AFD57"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34014
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace test5_ui {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Primitives.RepeatButton rBtnDes;
        
        internal System.Windows.Controls.TextBlock rTbNum;
        
        internal System.Windows.Controls.Primitives.RepeatButton rBtnAdd;
        
        internal System.Windows.Controls.StackPanel checkPanel;
        
        internal System.Windows.Controls.CheckBox cbk1;
        
        internal System.Windows.Controls.CheckBox cbk2;
        
        internal System.Windows.Controls.CheckBox cbk3;
        
        internal System.Windows.Controls.Button submit;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/test5-ui;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.rBtnDes = ((System.Windows.Controls.Primitives.RepeatButton)(this.FindName("rBtnDes")));
            this.rTbNum = ((System.Windows.Controls.TextBlock)(this.FindName("rTbNum")));
            this.rBtnAdd = ((System.Windows.Controls.Primitives.RepeatButton)(this.FindName("rBtnAdd")));
            this.checkPanel = ((System.Windows.Controls.StackPanel)(this.FindName("checkPanel")));
            this.cbk1 = ((System.Windows.Controls.CheckBox)(this.FindName("cbk1")));
            this.cbk2 = ((System.Windows.Controls.CheckBox)(this.FindName("cbk2")));
            this.cbk3 = ((System.Windows.Controls.CheckBox)(this.FindName("cbk3")));
            this.submit = ((System.Windows.Controls.Button)(this.FindName("submit")));
        }
    }
}

