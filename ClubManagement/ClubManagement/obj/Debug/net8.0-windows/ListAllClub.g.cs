﻿#pragma checksum "..\..\..\ListAllClub.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DFCA0C85D392E4F56FE73DDC3D9CC7961D0D7B75"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClubManagement;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClubManagement {
    
    
    /// <summary>
    /// ListAllClub
    /// </summary>
    public partial class ListAllClub : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClubId;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClubName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEstablishDate;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnJoin;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ListAllClub.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDataClub;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClubManagement;component/listallclub.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ListAllClub.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtClubId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtClubName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dpEstablishDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\ListAllClub.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnJoin = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\ListAllClub.xaml"
            this.btnJoin.Click += new System.Windows.RoutedEventHandler(this.btnJoin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgDataClub = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\..\ListAllClub.xaml"
            this.dgDataClub.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgDataClub_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

