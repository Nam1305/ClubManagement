﻿#pragma checksum "..\..\..\ChairmanTask.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63B36AE707E53792A6B7E4D7A54393E1604D879B"
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
    /// ChairmanTask
    /// </summary>
    public partial class ChairmanTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTask;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMember;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskId;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskName;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAssignedTo;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbPending;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbInprocess;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbCompleted;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDueDate;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\ChairmanTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
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
            System.Uri resourceLocater = new System.Uri("/ClubManagement;component/chairmantask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ChairmanTask.xaml"
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
            this.dgTask = ((System.Windows.Controls.DataGrid)(target));
            
            #line 30 "..\..\..\ChairmanTask.xaml"
            this.dgTask.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgTask_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgMember = ((System.Windows.Controls.DataGrid)(target));
            
            #line 43 "..\..\..\ChairmanTask.xaml"
            this.dgMember.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgMember_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTaskId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtTaskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtAssignedTo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.rbPending = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.rbInprocess = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.rbCompleted = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.dpDueDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\ChairmanTask.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\ChairmanTask.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click_1);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\ChairmanTask.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

