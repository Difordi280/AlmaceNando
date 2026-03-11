using AlmaceNando.Domain.Models.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Documents;

namespace AlmaceNando.App.ModelItem
{
    public partial class AccountDtos:ObservableObject
    {
        [ObservableProperty]
        private string _table = string.Empty;

        public DateTime CreationTime { get; } = DateTime.Now;

        [ObservableProperty]
        public ObservableCollection<CartItem> _cart = new ObservableCollection<CartItem>();

        [ObservableProperty]
        private decimal _grandTotal;

        public string Time => RefreshTime();

        public string RefreshTime()
        {
            
            TimeSpan diff = DateTime.Now - CreationTime;
            if (diff.TotalMinutes < 1) return "Ahora";
            else if (diff.TotalMinutes > 1 &&  diff.TotalSeconds < 59)
            return $"Hace {(int)diff.TotalMinutes} min";

            return $"Hace {(int)diff.Hours}hr {(int)diff.Minutes} min";
            

        }
        public AccountDtos()
        {
            WeakReferenceMessenger.Default.Register<CartTotalMessage>(this, (r, m) =>
            {
                GrandTotal += m.Value;
            });
        }

        public void UpdateTimeBinding()
        {
            // Esto obliga al XAML a volver a ejecutar: public string Time => RefreshTime();
            OnPropertyChanged(nameof(Time));
        }

        public void NameTable (int i)
        { 
            Table = $"Cuenta {i}";
        }


        


    }
}
