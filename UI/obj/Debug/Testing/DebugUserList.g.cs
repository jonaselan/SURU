﻿#pragma checksum "..\..\..\Testing\DebugUserList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9EE11C351386898B27524E381A7A43CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using UI.Testing;


namespace UI.Testing {
    
    
    /// <summary>
    /// DebugUserList
    /// </summary>
    public partial class DebugUserList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Testing\DebugUserList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.Testing.DebugUserList DebugUserListWindow;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Testing\DebugUserList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgUsuarios;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Testing\DebugUserList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelecionar;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Testing\DebugUserList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UI;component/testing/debuguserlist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Testing\DebugUserList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DebugUserListWindow = ((UI.Testing.DebugUserList)(target));
            
            #line 9 "..\..\..\Testing\DebugUserList.xaml"
            this.DebugUserListWindow.Loaded += new System.Windows.RoutedEventHandler(this.DebugUserListWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgUsuarios = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\Testing\DebugUserList.xaml"
            this.dgUsuarios.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dgUsuarios_SelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnSelecionar = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Testing\DebugUserList.xaml"
            this.btnSelecionar.Click += new System.Windows.RoutedEventHandler(this.btnSelecionar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

