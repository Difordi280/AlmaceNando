using AlmaceNando.Domain.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AlmaceNando.App.ViewModel
{
    public partial class LoginViewModel: ObservableValidator
    {

        
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _errorMessager;


       

       
        [RelayCommand]
        private async Task Login(object parameter)
        {

            if (parameter is PasswordBox passwordBox)
            {

                try
                {
                    string password = passwordBox.Password;

                    // se pregunta  si el login fue exitoso
                    bool IsSuccess = true;

                    if (IsSuccess)
                    {

                        var window = System.Windows.Window.GetWindow(passwordBox);

                        if (window != null) window?.DialogResult = true;

                        window.Close();

                    }
                }
                catch (Exception ex)
                {
                    ErrorMessager = "Ingresa nuevamente la Contraseña";
                    return;
                }
            }
        }



    }
}
