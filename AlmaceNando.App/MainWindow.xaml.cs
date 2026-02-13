using AlmaceNando.App.ViewModel;
using System.Windows;

namespace AlmaceNando.App
{
    public partial class MainWindow 
    {
        public MainWindow(MainViewModel viewModel )
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}