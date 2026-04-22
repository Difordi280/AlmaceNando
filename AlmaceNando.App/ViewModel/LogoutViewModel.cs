using AlmaceNando.Domain.Services;
using AlmaceNando.Logic.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AlmaceNando.App.ViewModel
{
    public partial class LogoutViewModel:ObservableValidator
    {
        private readonly IServiceLogin _serviceLogin;
        private readonly IServiceLogout _serviceLogout;

        [ObservableProperty]
        private string _physicalCash;

        [ObservableProperty]
        private decimal? _systemTotal;

        public LogoutViewModel(IServiceLogin serviceLogin, IServiceLogout serviceLogout)
        {
            _serviceLogin = serviceLogin;
            _serviceLogout = serviceLogout;

        }


        [RelayCommand]
        private async Task RevealResults(object parameter)
        {
            if (parameter is HandyControl.Controls.PasswordBox passwordBox)
            {
                string password = passwordBox.Password;

                 decimal? IsSuccess = await _serviceLogout.IsAuthenticated(password);

                if (IsSuccess != null)
                {
                    SystemTotal= IsSuccess ;
                }

            }

        }



    }
}
