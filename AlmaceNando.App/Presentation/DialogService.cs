using AlmaceNando.Domain.Services;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools.Extension;
using System;
using System.Threading.Tasks;
using System.Windows;
// Usamos el alias para evitar cualquier duda
using HC = HandyControl.Controls;

namespace AlmaceNando.App.Presentation
{
    public class DialogService : IDialogService
    {

        public async Task<decimal?> RequestAmount(string title, string messenger)
        {
            // 1. Crear el TextBox más simple posible
            var input = new HandyControl.Controls.TextBox
            {
                Margin = new System.Windows.Thickness(10),
                Width = 250
            };

            // Usamos el método más básico para poner el texto de ayuda
            input.SetValue(HandyControl.Controls.InfoElement.PlaceholderProperty, messenger);

            bool datoValido = false;
            decimal resultadoFinal = 0;

            while (!datoValido)
            {
                // 2. Mostrar el diálogo y esperar
                var dialog = HandyControl.Controls.Dialog.Show(input);
                var isOk = await dialog.GetResultAsync<bool>();

                // Si el usuario canceló, salimos
                if (!isOk) return null;

                // 3. VALIDACIÓN MANUAL
                if (decimal.TryParse(input.Text, out resultadoFinal) && resultadoFinal >= 0)
                {
                    datoValido = true;
                }
                else
                {
                    // Si el dato está mal, usamos el MessageBox de la librería que es estándar
                    HandyControl.Controls.MessageBox.Show("Por favor, ingrese un número válido mayor a cero.", "Error de entrada");
                    // El bucle 'while' hará que el diálogo se abra otra vez para que corrija
                }
            }

            return resultadoFinal;
        }


        public bool Confirm( string messenger)
        {
            return true;
        }





    }
}