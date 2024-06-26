﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewsModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        public string usuario = string.Empty;
        [ObservableProperty]
        public string password = string.Empty;

        [RelayCommand]
        private async Task Login()
        {
            if(Usuario == "Milton" && Password == "Milton")
            {
                Preferences.Set("logueado", "si");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese un usuario y contraseña valido", "Aceptar");
            }
        }
    }
}
