using System.Collections.ObjectModel;
using System.Linq; // Necesario para FirstOrDefault
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AlmaceNando.App
{
    // --- MODELOS ---
    public class AccountModel
    {
        public string Name { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }

    public class ProductModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class CartItemModel
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total => Price * Qty;
    }

    // --- VIEW MODEL ---
    public partial class MainViewModel : ObservableObject
    {
        // Colecciones
        public ObservableCollection<AccountModel> Accounts { get; } = new();
        public ObservableCollection<ProductModel> Products { get; } = new();
        public ObservableCollection<CartItemModel> Cart { get; } = new();

        [ObservableProperty]
        private decimal _grandTotal;

        public MainViewModel()
        {
            LoadSampleData();
        }

        // Comandos
        [RelayCommand]
        private void AddToCart(ProductModel product)
        {
            var existingItem = Cart.FirstOrDefault(x => x.Name == product.Name);
            if (existingItem != null)
            {
                // Truco para refrescar la UI en listas simples: remover e insertar (o usar una clase Observable completa)
                int index = Cart.IndexOf(existingItem);
                Cart.RemoveAt(index);
                existingItem.Qty++;
                Cart.Insert(index, existingItem);
            }
            else
            {
                Cart.Add(new CartItemModel
                {
                    Name = product.Name,
                    Price = product.Price,
                    Qty = 1
                });
            }
            CalculateTotal();
        }

        [RelayCommand]
        private void RemoveFromCart(CartItemModel item)
        {
            if (Cart.Contains(item))
            {
                Cart.Remove(item);
                CalculateTotal();
            }
        }

        [RelayCommand]
        private void ClearCart()
        {
            Cart.Clear();
            CalculateTotal();
        }

        [RelayCommand]
        private void Checkout()
        {
            System.Diagnostics.Debug.WriteLine($"Checkout realizado. Total: {GrandTotal:C}");
        }

        private void LoadSampleData()
        {
            // Cuentas
            Accounts.Add(new AccountModel { Name = "Mesa 5", User = "Cliente General", Time = "10 min", Total = 15.90m });
            Accounts.Add(new AccountModel { Name = "Mesa 1", User = "Ana García", Time = "5 min", Total = 3.90m });
            Accounts.Add(new AccountModel { Name = "Juan Deudor", User = "Crédito", Time = "1h", Total = 15.80m });
            Accounts.Add(new AccountModel { Name = "Mesa 12", User = "Familia Perez", Time = "25m", Total = 45.00m });

            // Productos
            Products.Add(new ProductModel { Name = "Leche 1L", Price = 1.50m, Category = "Lácteos", Icon = "🥛" });
            Products.Add(new ProductModel { Name = "Pan Artesanal", Price = 3.20m, Category = "Panadería", Icon = "🥖" });
            Products.Add(new ProductModel { Name = "Manzanas", Price = 4.50m, Category = "Frutas", Icon = "🍎" });
            Products.Add(new ProductModel { Name = "Hamburguesa", Price = 8.50m, Category = "Carnes", Icon = "🍔" });
            Products.Add(new ProductModel { Name = "Café", Price = 12.00m, Category = "Bebidas", Icon = "☕" });
            Products.Add(new ProductModel { Name = "Vino Tinto", Price = 25.00m, Category = "Licores", Icon = "🍷" });

            // Carrito inicial
            AddToCart(Products[0]); // Leche
            AddToCart(Products[0]); // Leche (x2)
            AddToCart(Products[1]); // Pan
        }

        private void CalculateTotal()
        {
            GrandTotal = Cart.Sum(x => x.Total);
        }
    }
}