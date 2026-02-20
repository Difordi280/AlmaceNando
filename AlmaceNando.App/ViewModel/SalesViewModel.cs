using AlmaceNando.Domain.Models.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AlmaceNando.App.ViewModel
{
    public partial class SalesViewModel : ViewModelBase
    {
        public override int Priority => 1;
        public override string ViewName => "Ventas";

        [ObservableProperty]
        private ObservableCollection<CartItem> _cart;
        
        public SalesViewModel() 
        { 
            Cart= new ObservableCollection<CartItem>();

            //agrega un producto para ver como se ve la tarjeta
            Cart.Add(new CartItem()
            {
                Name = "Papas",
                Price = 12,

            });

            Cart.Add(new CartItem()
            {
                Name = "Detodito grande de limon 180g",
                Price = 30000

            }); 

        }





    
    
    }
}

 