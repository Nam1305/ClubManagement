﻿#pragma checksum "..\..\..\TeamLeaderhome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "073AD34FC6293B4F1E41A4EFF86B6F813259E070"
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
    /// TeamLeaderhome
    /// </summary>
    public partial class TeamLeaderhome : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl TabControl;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView GroupsListView;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TasksListView;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTaskButton;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ChatListView;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MessageTextBox;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\TeamLeaderhome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendMessageButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ClubManagement;V1.0.0.0;component/teamleaderhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TeamLeaderhome.xaml"
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
            this.TabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.GroupsListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.TasksListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.AddTaskButton = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\TeamLeaderhome.xaml"
            this.AddTaskButton.Click += new System.Windows.RoutedEventHandler(this.AddTaskButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ChatListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.MessageTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 109 "..\..\..\TeamLeaderhome.xaml"
            this.MessageTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.MessageTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 109 "..\..\..\TeamLeaderhome.xaml"
            this.MessageTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.MessageTextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SendMessageButton = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\TeamLeaderhome.xaml"
            this.SendMessageButton.Click += new System.Windows.RoutedEventHandler(this.SendMessageButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 37 "..\..\..\TeamLeaderhome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewGroupMembers_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 38 "..\..\..\TeamLeaderhome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateGroupStatus_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 69 "..\..\..\TeamLeaderhome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateTaskStatus_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 70 "..\..\..\TeamLeaderhome.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteTask_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

