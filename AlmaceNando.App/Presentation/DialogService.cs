using AlmaceNando.Domain.Presentation;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Extension;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

// Usamos el alias para evitar cualquier duda
using HC = HandyControl.Controls;

namespace AlmaceNando.App.Presentation
{
    public class DialogService : IDialogService
    {


        public async Task<decimal?> RequestAmount(string messenger, string title, bool canCancel = true)
        {
            return await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var window = new HandyControl.Controls.Window
                {
                    Title = title,
                    Width = 350,
                    Height = 220,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    ResizeMode = ResizeMode.NoResize,
                    ShowInTaskbar = false,
                    Topmost = true,
                    Background = (Brush)Application.Current.Resources["RegionBrush"]
                };

                // Si es obligatorio (canCancel = false), quitamos la barra de título
                if (!canCancel) window.WindowStyle = WindowStyle.None;

                // Impedir cierre accidental con Alt+F4 si es obligatorio
                window.Closing += (s, e) => {
                    if (window.DialogResult != true && !canCancel) e.Cancel = true;
                };

                var stack = new StackPanel { Margin = new Thickness(20) };

                stack.Children.Add(new TextBlock
                {
                    Text = title,
                    FontWeight = FontWeights.Bold,
                    FontSize = 16,
                    Margin = new Thickness(0, 0, 0, 10)
                });

                var input = new HandyControl.Controls.TextBox
                {
                    Margin = new Thickness(0, 10, 0, 20),
                    Height = 35,
                    FontSize = 16,
                    HorizontalContentAlignment = HorizontalAlignment.Right
                };
                input.SetValue(HandyControl.Controls.InfoElement.PlaceholderProperty, messenger);
                input.Focus(); // Para que el usuario empiece a escribir de inmediato

                // Formateo de miles tipo calculadora
                bool isFormatting = false;
                input.TextChanged += (s, e) => {
                    if (isFormatting) return;
                    isFormatting = true;

                    string rawValue = new string(input.Text.Where(char.IsDigit).ToArray());
                    if (decimal.TryParse(rawValue, out decimal res))
                    {
                        input.Text = string.Format("{0:N0}", res);
                        input.SelectionStart = input.Text.Length;
                    }
                    isFormatting = false;
                };

                var buttonGrid = new Grid();
                buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                var btnConfirmar = new Button
                {
                    Content = "Confirmar",
                    Style = (Style)Application.Current.Resources["ButtonPrimary"],
                    Margin = new Thickness(5, 0, 0, 0),
                    Height = 35,
                    IsDefault = true // Esto permite que la tecla ENTER funcione automáticamente
                };
                Grid.SetColumn(btnConfirmar, 1);

                btnConfirmar.Click += (s, e) => {
                    string clean = new string(input.Text.Where(char.IsDigit).ToArray());
                    if (decimal.TryParse(clean, out _))
                    {
                        window.DialogResult = true;
                    }
                    else
                    {
                        HandyControl.Controls.MessageBox.Show("Por favor, ingrese un monto válido.");
                    }
                };

                if (canCancel)
                {
                    var btnCancelar = new Button
                    {
                        Content = "Cancelar",
                        Margin = new Thickness(0, 0, 5, 0),
                        Height = 35,
                        IsCancel = true // Esto permite que la tecla ESC funcione automáticamente
                    };
                    btnCancelar.Click += (s, e) => window.DialogResult = false;
                    buttonGrid.Children.Add(btnCancelar);
                }

                buttonGrid.Children.Add(btnConfirmar);
                stack.Children.Add(input);
                stack.Children.Add(buttonGrid);
                window.Content = stack;

                // Ejecución del diálogo
                if (window.ShowDialog() == true)
                {
                    string finalValue = new string(input.Text.Where(char.IsDigit).ToArray());
                    return decimal.TryParse(finalValue, out decimal res) ? (decimal?)res : null;
                }

                return null;
            });
        }

     




    }
}