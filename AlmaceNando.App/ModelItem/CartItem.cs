using AlmaceNando.Domain.Models.Inventory;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlmaceNando.Domain.Models.DTOs
{
    public class CartTotalMessage: ValueChangedMessage<decimal>
    {
        public CartTotalMessage(decimal total) : base(total) { }
    }

    public partial class CartItem : ObservableValidator
    {
        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _quantity = 0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private decimal _price;

        public Guid Id { get; set; }
        public int Stock {  get; set; }

        public decimal Total => Price * Convert.ToInt16(Quantity);


        public CartItem(Product product)
        {
            Id = product.Id;
            Name= product.Name;
            Price= product.Price;
            Stock= product.Stock;

        }


        partial void OnQuantityChanged(int oldValue, int newValue)
        {
            decimal difference = (newValue * Price) - (oldValue * Price);


            WeakReferenceMessenger.Default.Send(new CartTotalMessage(difference));
        }

       

    }
}
