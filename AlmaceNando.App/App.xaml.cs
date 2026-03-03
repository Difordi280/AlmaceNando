using System.Configuration;
using System.Data;
using System.Windows;
using AlmaceNando.App.ViewModel;
using AlmaceNando.Data.Context;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Logic.ServiceSales;
using AlmaceNando.Logic.Interfaces;

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

            // esto es para que funcione la inyeccion dinamica 
            services.AddSingleton<SalesViewModel>();
            services.AddSingleton<ViewModelBase>(provider => provider.GetRequiredService<SalesViewModel>());
            //
            services.AddSingleton<MainWindow>();

            services.AddDbContext<StoreContext>();

            // Añade esta línea antes de registrar los ViewModels y Servicios
            services.AddScoped (typeof(IRepository<>), typeof(Repositories<>));
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IServiceSales,ServiceSales>();

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
