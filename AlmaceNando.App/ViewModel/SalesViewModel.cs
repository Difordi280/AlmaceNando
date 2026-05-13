using AlmaceNando.App.ModelItem;
using AlmaceNando.Data.Context;
using AlmaceNando.Domain.Models.DTOs;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Models.People;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Domain.Services;
using AlmaceNando.Logic.DoTS;
using AlmaceNando.Logic.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace AlmaceNando.App.ViewModel
{
    public partial class SalesViewModel : ViewModelBase
    {
        public override int Priority => 1;
        public override string ViewName => "Ventas";

        //Metodos principales 
        private void ResetToken()
        {
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();

        }
        private DispatcherTimer Timer;

        private readonly IProductRepository _productRepository;
        
        private readonly IServiceSales _serviceSales;

        private readonly ISessionService _user;

        
        private CancellationTokenSource? _cts;

        //activador de buscador 
        [ObservableProperty]
        private string? _searchText;
        //el selecionado por el cliente 
        [ObservableProperty]
        private Product? _selectedProduct;

        [ObservableProperty]
        public ObservableCollection<AccountDtos> _account = new ObservableCollection<AccountDtos>();

        [ObservableProperty]
        private AccountDtos? _selectAccounts= new() ;
        public ObservableCollection<Product> Items { get; } = new();

        

        public SalesViewModel(IProductRepository productRepository,IServiceSales serviceSales,ISessionService user)
        {
            _productRepository = productRepository;
            _serviceSales = serviceSales;
            _user = user;
            ResetToken();
            _ = GetProductsAsync("");
            SetUpTimer();

        }
        partial void OnSearchTextChanged(string? value)
        {
            // Cancelamos la tarea anterior de forma segura
            ResetToken();
            _ = GetProductsAsync(value, _cts.Token);
        }


        //Para agregar solo el primer producto que esta en la lista de observable
        [RelayCommand]
        public void AddFistProduct()
        {
             AddProductToCart(Items[0]);
        }

        //Cuando Presionas enter y el producto esta repetido , solo se lo suma
        //Si lo esta se agrega con una nueva tarjeta 
        [RelayCommand]
        public void AddProductToCart(Product? product)
        {
            if (product == null) return;
            CartItem? i = SelectAccounts.Cart.FirstOrDefault(p => p.Id == product.Id);
                
            if(i == null) 
            {
                CartItem item = new CartItem(product);
                SelectAccounts.GrandTotal += item.Total;
                SelectAccounts.Cart.Add(item);
            }
            else 
            {
                i.Quantity++;
            }
        }

        private void SetUpTimer()
        {
            Timer = new DispatcherTimer();

            Timer.Interval = TimeSpan.FromMinutes(2);

            Timer.Tick += (sender, e) =>
            {
                foreach(var item in Account )
                {
                    item.RefreshTime();
                    item.UpdateTimeBinding();
                }
            };
            Timer.Start();
        }


        private async Task GetProductsAsync(string write, CancellationToken token = default)
        {
            try
            {
                // Debounce profesional: evita peticiones por cada tecla
                await Task.Delay(700, token);

                var products = await _productRepository.Search(write, token);

                // Regresamos al hilo de UI para modificar la colección
                Items.Clear();
                if (products != null)
                {
                    foreach (var item in products)
                    {
                        Items.Add(item);
                    }
                }

            }
            catch (OperationCanceledException) { } // Ignorado: es una cancelación controlada 
            catch (Exception ex) { } // Aquí puedes usar un Logger profesional           
        }


       


        [RelayCommand]
        private async Task ProccessSale()
        {

            string mensaje = "¿Desea confirmar la venta y procesar el pago?";
            string titulo = "Confirmación de Venta";

            // 2. Lanzamos la ventana emergente con botones Sí/No
            // El icono 'Question' le da ese toque de "prioridad de confirmación" que buscas
            MessageBoxResult resultado = HandyControl.Controls.MessageBox.Show(mensaje, titulo, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            // 3. Evaluamos la decisión del vendedor
            if (resultado == MessageBoxResult.Yes)
            {
                try
                {
                    var NewSales = SelectAccounts.Cart.Select(i => new SalesItem
                    {
                        Use = _user.CurrentUser,
                        Id = i.Id,
                        Quantity = i.Quantity,
                        Price = i.Price,

                    }).ToList();


                    await _serviceSales.ProccessSales(SelectAccounts.GrandTotal, NewSales);

                    SelectAccounts.Cart.Clear();
                    SelectAccounts.GrandTotal = 0;


                    HandyControl.Controls.MessageBox.Show("Venta realizada con éxito.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Aquí podrías limpiar el carrito para una nueva venta
                }
                catch (Exception ex)
                {
                    HandyControl.Controls.MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Si dice que NO, simplemente salimos del método sin hacer nada
                // El vendedor puede seguir modificando el carrito si quiere
                return;
            }
          
        }

        [RelayCommand]
        private void AddAccount()
        {
            AccountDtos Table = new AccountDtos();
            Table.NameTable(Account.Count()+1);
            Account.Add(Table);
        }


        [RelayCommand]
        private void RemoveItem(CartItem cart)
        {
            if (cart == null) return;
            SelectAccounts.GrandTotal -= cart.Total;
            SelectAccounts.Cart.Remove(cart);
        }



    }
}

 