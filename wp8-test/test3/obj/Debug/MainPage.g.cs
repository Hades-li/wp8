﻿#pragma checksum "D:\developSpace\wp8Space\GitHub\wp8\wp8-test\test3\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F9FE570D117F6B9FF9B090CD74553813"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.34209
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


namespace test3 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txtX;
        
        internal System.Windows.Controls.TextBox txtY;
        
        internal System.Windows.Controls.TextBox txtZ;
        
        internal System.Windows.Controls.Button btn_ok;
        
        internal System.Windows.Controls.TextBox txtData;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/test3;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtX = ((System.Windows.Controls.TextBox)(this.FindName("txtX")));
            this.txtY = ((System.Windows.Controls.TextBox)(this.FindName("txtY")));
            this.txtZ = ((System.Windows.Controls.TextBox)(this.FindName("txtZ")));
            this.btn_ok = ((System.Windows.Controls.Button)(this.FindName("btn_ok")));
            this.txtData = ((System.Windows.Controls.TextBox)(this.FindName("txtData")));
        }
    }
}

