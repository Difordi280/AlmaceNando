using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Domain.Models.DTOs
{
    public partial class CartItem: ObservableValidator
    {
        [ObservableProperty]
        private string? _name  ;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof( Total))]
        private decimal _quantity;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private decimal _price ;


        public decimal Total => Price * Quantity;


    }
}
