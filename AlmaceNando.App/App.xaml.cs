using AlmaceNando.App.Presentation;
using AlmaceNando.App.View;
using AlmaceNando.App.ViewModel;
using AlmaceNando.Data.Context;
using AlmaceNando.Data.Repositories;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Presentation;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using AlmaceNando.Logic.Interfaces;
using AlmaceNando.Logic.Service;
using AlmaceNando.Logic.ServiceSales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

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

            // --- 1. CAPA DE DATOS Y LÓGICA (Los cimientos) ---
            services.AddDbContext<StoreContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repositories<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHistoryReposiory,UserHistoryRepository>();
            services.AddScoped<ISaleHistoryRepository,SaleHistoryRepository>();

            // Servicios de negocio
            services.AddTransient<IServiceSales, ServiceSales>();
            services.AddSingleton<IServiceLogin, ServiceLogin>(); 
            services.AddTransient<IServiceLogout, ServiceLogout>();

            // Servicio de vista
            services.AddTransient<IDialogService, DialogService>();
            


            services.AddTransient<LoginViewModel>();
            services.AddTransient<LogoutViewModel>();
            
            
            services.AddTransient<LoginWindow>();
            services.AddTransient<LogoutWindow>();  




            // --- 2. CAPA DE PRESENTACIÓN (Los edificios) ---
            services.AddTransient<MainViewModel>();

            // Registro del SalesViewModel y su base dinámica
            services.AddSingleton<SalesViewModel>();
            services.AddSingleton<ViewModelBase>(provider => provider.GetRequiredService<SalesViewModel>());

            // Ventanas
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Pedimos la MainWindow directamente
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            // 2. La mostramos de una vez. La app ya es funcional.
            mainWindow.Show();
        }

    }

}
