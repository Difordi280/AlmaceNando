using AlmaceNando.App.View;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Presentation;
using AlmaceNando.Domain.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AlmaceNando.App.ViewModel
{
    public partial class MainViewModel: ObservableValidator
    {
        [ObservableProperty]
        private ViewModelBase _current;


        public ObservableCollection<ViewModelBase> InjectedModules { get; set; }

        private readonly IServiceProvider _serviceProvider;

        private readonly IServiceLogin _user;

        private readonly IDialogService _dialogService;



        public MainViewModel(IEnumerable<ViewModelBase> listviewmodles, IServiceProvider serviceProvider,IServiceLogin user,IDialogService dialogService)
        {
            _serviceProvider = serviceProvider;
            _user = user;

            _dialogService = dialogService;

            var order = listviewmodles
                .OrderBy(x => x.Priority)
                .ThenBy(x => x.ViewName);

            InjectedModules = new ObservableCollection<ViewModelBase>(order);

            Current = InjectedModules[0];
            
        }


        [RelayCommand]
        private void HandleAuthAction()
        {
            string messenger = " ";

            if (_user.IsLoggedIn)
            {

                var logoutWin = _serviceProvider.GetRequiredService<LogoutWindow>();
                if (logoutWin.ShowDialog() == true)
                {
                    // Forzamos la notificación de todas las propiedades relacionadas al usuario
                    messenger = "Cuanto dinero quedo en la caja";
                    _dialogService.RequestAmount(messenger, "prueba",false);
                }
            }
            else
            {
                var loginWin = _serviceProvider.GetRequiredService<LoginWindow>();
                if (loginWin.ShowDialog() == true)
                {

                    messenger = "Cuanto dinero se dejo en la caja";
                    _dialogService.RequestAmount(messenger, "prueba",false);
                    //// Forzamos la notificación de todas las propiedades relacionadas al usuario
                    //NotifyUserChanges();
                }
            }

            // aca es para que se coloque cuanto dinero ahi en la caja cuando se abra o cuando se cierre la caja

            NotifyUserChanges();

            //!!MODULAR EN UN FUTURO!!

           

        }

        // Método auxiliar para no repetir código
        private void NotifyUserChanges()
        {
            OnPropertyChanged(nameof(AuthActionText));
            OnPropertyChanged(nameof(UserInitial));
            OnPropertyChanged(nameof(UserNameDisplay));
            OnPropertyChanged(nameof(UserRol));
        }

        // Propiedad para el nombre completo al lado del círculo
        public string UserNameDisplay => _user.IsLoggedIn ? _user.CurrentUser.Name : "Invitado";

        public string AuthActionText => _user.IsLoggedIn ? "Cerrar Sesión" : "Iniciar Sesión";

        public string UserInitial => (_user.IsLoggedIn && !string.IsNullOrEmpty(_user.CurrentUser?.Name))
            ? _user.CurrentUser.Name[0].ToString().ToUpper()
            : "?";

        public string UserRol => _user.IsLoggedIn ? _user.CurrentUser.Rol : "NN";


    }
}
