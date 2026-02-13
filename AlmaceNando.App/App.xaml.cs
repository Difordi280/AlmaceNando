using System.Configuration;
using System.Data;
using System.Windows;
using AlmaceNando.App.ViewModel;
using AlmaceNando.Data.Context;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlmaceNando.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();


            //Añadimos Viewmodels
            services.AddTransient<MainViewModel>();
            services.AddTransient< ViewModelBase,SalesViewModel>();

            //
            services.AddSingleton<MainWindow>();


            _serviceProvider = services.BuildServiceProvider();

        }


        protected override void OnStartup(StartupEventArgs e)
        {
            // Se solicita la ventana al contenedor para que inyecte todo
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

    }

}
