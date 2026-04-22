using AlmaceNando.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlmaceNando.App.View
{
    /// <summary>
    /// Lógica de interacción para LogoutWindow.xaml
    /// </summary>
    public partial class LogoutWindow : HandyControl.Controls.Window
    {
        public LogoutWindow(LogoutViewModel vm )
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
