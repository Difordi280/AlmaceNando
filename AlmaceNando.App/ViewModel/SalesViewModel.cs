using AlmaceNando.Data.Context;
using AlmaceNando.Domain.Models.DTOs;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System;
using AlmaceNando.Logic.Interfaces;
using AlmaceNando.Logic.DoTS;

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

        private readonly IProductRepository _productRepository;
        
        private readonly IServiceSales _serviceSales;
        
        private CancellationTokenSource? _cts;

        //activador de buscador 
        [ObservableProperty]
        private string? _searchText;
        //el selecionado por el cliente 
        [ObservableProperty]
        private Product? _selectedProduct;

        [ObservableProperty]
        private decimal _grandTotal = 0;

        public ObservableCollection<CartItem> Cart { get; set; } = new ObservableCollection<CartItem>();
        public ObservableCollection<Product> Items { get; } = new();

        public SalesViewModel(IProductRepository productRepository,IServiceSales serviceSales)
        {
            _productRepository = productRepository;
            _serviceSales = serviceSales;
            ResetToken();
            _ = GetProductsAsync("");



            WeakReferenceMessenger.Default.Register<CartTotalMessage>(this,(r,m)=>
            {
                GrandTotal += m.Value;
            });


        }
        partial void OnSearchTextChanged(string? value)
        {
            // Cancelamos la tarea anterior de forma segura
            ResetToken();

            _ = GetProductsAsync(value, _cts.Token);
        }



        [RelayCommand]
        public void AddProductToCart(Product? product)
        {
            if (product == null) return;
            CartItem? i = Cart.FirstOrDefault(p => p.Id == product.Id);
                
            if(i == null) 
            {
                CartItem item = new CartItem(product);
                GrandTotal += item.Total;
                Cart.Add(item);
            }
            else 
            {
                i.Quantity++;
            }
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
        private void RemoveItem(CartItem cart)
        {
            if (cart == null) return;
            GrandTotal -= cart.Total;
            Cart.Remove(cart);
        }


        [RelayCommand]
        private async Task ProccessSale()
        {

            string mensaje = "¿Desea confirmar la venta y procesar el pago?";
            string titulo = "Confirmación de Venta";

            // 2. Lanzamos la ventana emergente con botones Sí/No
            // El icono 'Question' le da ese toque de "prioridad de confirmación" que buscas
            MessageBoxResult resultado = MessageBox.Show(mensaje, titulo, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            // 3. Evaluamos la decisión del vendedor
            if (resultado == MessageBoxResult.Yes)
            {
                try
                {


                    var NewSales = Cart.Select(i => new SalesItem
                    {
                        Id = i.Id,
                        Quantity = i.Quantity,
                        Price = i.Price,

                    }).ToList();


                    await _serviceSales.ProccessSales(GrandTotal, NewSales);

                    Cart.Clear();
                    GrandTotal = 0;


                    MessageBox.Show("Venta realizada con éxito.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Aquí podrías limpiar el carrito para una nueva venta
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Si dice que NO, simplemente salimos del método sin hacer nada
                // El vendedor puede seguir modificando el carrito si quiere
                return;
            }


          
        }








    }
}

 