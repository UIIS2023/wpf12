﻿#pragma checksum "..\..\..\Forme\FrmProizvodjac.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DF810009E5F8D6437D1AAF40374093F558665ABEB7192743B0BF836A27785F68"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SalonNamestaja.Forme;
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


namespace SalonNamestaja.Forme {
    
    
    /// <summary>
    /// FrmProizvodjac
    /// </summary>
    public partial class FrmProizvodjac : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Forme\FrmProizvodjac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNazivProizvodjaca;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Forme\FrmProizvodjac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLokacijaProizvodjaca;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Forme\FrmProizvodjac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKontaktProizvodjaca;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Forme\FrmProizvodjac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Forme\FrmProizvodjac.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOtkazi;
        
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
            System.Uri resourceLocater = new System.Uri("/SalonNamestaja;component/forme/frmproizvodjac.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forme\FrmProizvodjac.xaml"
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
            this.txtNazivProizvodjaca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtLokacijaProizvodjaca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtKontaktProizvodjaca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Forme\FrmProizvodjac.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnOtkazi = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Forme\FrmProizvodjac.xaml"
            this.btnOtkazi.Click += new System.Windows.RoutedEventHandler(this.btnOtkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

