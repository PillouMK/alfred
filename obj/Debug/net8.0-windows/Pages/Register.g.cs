﻿#pragma checksum "..\..\..\..\Pages\Register.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F3C625F7E85EFC3F58532CF9F311D861FB253CB7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Alfred.CustomControls;
using Alfred.Pages;
using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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


namespace Alfred.Pages {
    
    
    /// <summary>
    /// Register
    /// </summary>
    public partial class Register : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 134 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run userName;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Alfred.CustomControls.TextBoxWithPlaceHolder User_Input;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Alfred.CustomControls.TextBoxWithPlaceHolder Email_Input;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Alfred.CustomControls.TextBoxWithPlaceHolder Pasw_Input;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Alfred.CustomControls.TextBoxWithPlaceHolder Pasw_Confirm_Input;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login_Button;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome LoaderIcon;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\..\Pages\Register.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run Error_Message;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Alfred;component/pages/register.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Register.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 103 "..\..\..\..\Pages\Register.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Switch_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userName = ((System.Windows.Documents.Run)(target));
            return;
            case 3:
            this.User_Input = ((Alfred.CustomControls.TextBoxWithPlaceHolder)(target));
            return;
            case 4:
            this.Email_Input = ((Alfred.CustomControls.TextBoxWithPlaceHolder)(target));
            return;
            case 5:
            this.Pasw_Input = ((Alfred.CustomControls.TextBoxWithPlaceHolder)(target));
            return;
            case 6:
            this.Pasw_Confirm_Input = ((Alfred.CustomControls.TextBoxWithPlaceHolder)(target));
            return;
            case 7:
            this.Login_Button = ((System.Windows.Controls.Button)(target));
            
            #line 172 "..\..\..\..\Pages\Register.xaml"
            this.Login_Button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LoaderIcon = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 9:
            this.Error_Message = ((System.Windows.Documents.Run)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

