﻿#pragma checksum "..\..\..\ChairmanReport.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF07AC567868752354F7A0F58FB9E45435B1B065"
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
    /// ChairmanReport
    /// </summary>
    public partial class ChairmanReport : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgReports;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReportId;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCreateDate;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSemester;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMemberChanges;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEventSummary;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtParticipationStatus;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ChairmanReport.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClubId;
        
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
            System.Uri resourceLocater = new System.Uri("/ClubManagement;V1.0.0.0;component/chairmanreport.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ChairmanReport.xaml"
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
            this.dgReports = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\..\ChairmanReport.xaml"
            this.dgReports.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgReports_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtReportId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtCreateDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtSemester = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtMemberChanges = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtEventSummary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtParticipationStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtClubId = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

