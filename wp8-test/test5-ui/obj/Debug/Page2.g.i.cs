﻿#pragma checksum "D:\developSpace\wp8Space\GitHub\wp8\wp8-test\test5-ui\Page2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "895000C6FB881968AE75C8A3B814FF0A"
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


namespace test5_ui {
    
    
    public partial class Page2 : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBox urlInput;
        
        internal System.Windows.Controls.Button toUrlBtn;
        
        internal Microsoft.Phone.Controls.WebBrowser wb;
        
        internal System.Windows.Controls.TextBlock statuTxt;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/test5-ui;component/Page2.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.urlInput = ((System.Windows.Controls.TextBox)(this.FindName("urlInput")));
            this.toUrlBtn = ((System.Windows.Controls.Button)(this.FindName("toUrlBtn")));
            this.wb = ((Microsoft.Phone.Controls.WebBrowser)(this.FindName("wb")));
            this.statuTxt = ((System.Windows.Controls.TextBlock)(this.FindName("statuTxt")));
        }
    }
}

