using AlmaceNando.App.ViewModel;
using AlmaceNando.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using hc= HandyControl.Controls;


namespace AlmaceNando.App.View
{
    /// <summary>
    /// Lógica de interacción para SalesWindow.xaml
    /// </summary>
    public partial class SalesWindow : UserControl
    {

        private ListBoxItem? _lastFocusedCartItem;
        public SalesWindow()
        {
            InitializeComponent();


            this.Loaded += (s, e) =>
            {
                txtSearch.Focus();
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    txtSearch.SelectAll();
                }
            };
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }

        #region Eventos Principales (Teclado)
        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var element = FocusManager.GetFocusedElement(System.Windows.Window.GetWindow(this));

            switch (e.Key)
            {
                case Key k when IsLetter(k):
                    ProcessLetter(element);
                    break;

                case Key k when IsNumber(k):
                    ProcessNumber(element);
                    break;

                case Key k when IsArrow(k):
                    ProcessNavigation(k, element, e);
                    break;

                case Key.Enter:
                    ProcessAction(element, e);
                    break;

                case Key.Escape:
                    DeleteCartItem(element); ;
                    break;
                case Key.Delete:
                    DeleteCartItem(element);
                    e.Handled = true;
                    break;
                case Key.Add:
                case Key.OemPlus:
                    HandleQuantityChange(1);
                    e.Handled = true;
                    break;

                case Key.Subtract:
                case Key.OemMinus:
                    HandleQuantityChange(-1);
                    e.Handled = true;
                    break;

            }
        }
        #endregion

        private void lstCart_GotFocus(object sender, RoutedEventArgs e)
        {
            // Si el foco cayó en un ListBoxItem o algo dentro de él
            var item = ItemsControl.ContainerFromElement(lstCart, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                _lastFocusedCartItem = item;
            }
        }

        private void HandleQuantityChange(int delta)
        {
            // 1. Si no hay memoria de un ítem previo, intentamos agarrar el primero de la lista
            if (_lastFocusedCartItem == null && lstCart.Items.Count > 0)
            {
                _lastFocusedCartItem = lstCart.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
            }

            if (_lastFocusedCartItem != null)
            {
                // 2. ¡SALTO DE MEMORIA! Llevamos el foco al último ítem recordado
                _lastFocusedCartItem.Focus();
                lstCart.ScrollIntoView(_lastFocusedCartItem.DataContext);

                // 3. Obtenemos el producto (DataContext)
                var cartItem = _lastFocusedCartItem.DataContext as dynamic; // O tu clase CartItem
                if (cartItem != null)
                {
                    // 4. Cambiamos la cantidad (Esto asume que tu CartItem notifica cambios)
                    int newQty = cartItem.Quantity + delta;
                    if (newQty >= 1 && newQty <= 99)
                    {
                        cartItem.Quantity = newQty;
                    }
                }
            }
        }

        private void DeleteCartItem(object element)
        {
            if (lstCart.IsKeyboardFocusWithin)
            {
                object dataToDelete = null;

                if (element is ListBoxItem item)
                {
                    dataToDelete = item.DataContext;
                }
                else if (element is DependencyObject dep)
                {
                    var parentItem = FindParent<ListBoxItem>(dep);
                    dataToDelete = parentItem?.DataContext;
                }

                if (dataToDelete != null)
                {
                    // Casteamos al tipo real de tu ViewModel para evitar errores de 'dynamic'
                    if (this.DataContext is AlmaceNando.App.ViewModel.SalesViewModel viewModel)
                    {
                        // El Toolkit genera el comando con el sufijo "Command"
                        if (viewModel.RemoveItemCommand != null)
                        {
                            viewModel.RemoveItemCommand.Execute(dataToDelete);

                            if (lstCart.Items.Count == 0)
                            {
                                FocusSearch();
                            }
                            else
                            {
                                GoToListItem(lstCart);
                            }
                        }
                    }
                }
            }
        }

        // Función auxiliar necesaria para "subir" desde el TextBox hasta la fila
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            if (parentObject is T parent) return parent;
            return FindParent<T>(parentObject);
        }


        #region Lógica de Navegación

        private void ProcessNavigation(Key k, object element, KeyEventArgs e)
        {
            var currentItem = element as ListBoxItem;

            // 1. Buscador -> Productos (Se mantiene igual)
            if (k == Key.Down && element == txtSearch)
            {
                GoToListItem(lstProduct);
                e.Handled = true;
                return;
            }

            // 2. Productos -> Cesta (Derecha)
            if (lstProduct.IsKeyboardFocusWithin && currentItem != null && k == Key.Right)
            {
                if (IsAtRightEdge(currentItem))
                {
                    GoToListItem(lstCart);
                    e.Handled = true;
                    return;
                }
            }

            // 3. NAVEGACIÓN DENTRO DE LA CESTA (LA SOLUCIÓN)
            if (lstCart.IsKeyboardFocusWithin && (k == Key.Up || k == Key.Down))
            {
                // Buscamos el siguiente elemento visual (sin seleccionarlo)
                var direction = (k == Key.Down) ? FocusNavigationDirection.Down : FocusNavigationDirection.Up;

                // Movemos el foco manualmente
                if (FocusManager.GetFocusedElement(Window.GetWindow(this)) is UIElement focused)
                {
                    focused.MoveFocus(new TraversalRequest(direction));

                    // Si el nuevo foco cayó en un item de la cesta, nos aseguramos que se vea
                    var newFocus = FocusManager.GetFocusedElement(Window.GetWindow(this)) as ListBoxItem;
                    if (newFocus != null)
                    {
                        lstCart.ScrollIntoView(newFocus.DataContext);
                    }
                }

                e.Handled = true; // DETENEMOS al ListView para que no pinte la selección
                return;
            }

            // 4. Cesta -> Productos (Izquierda)
            if (lstCart.IsKeyboardFocusWithin && k == Key.Left)
            {
                lstCart.SelectedIndex = -1;
                GoToListItem(lstProduct);
                e.Handled = true;
            }
        }

        private void GoToListItem(ListBox lista)
        {
            if (lista == null || lista.Items.Count == 0) return;

            // Navegamos por FOCO, no por SELECCIÓN
            lista.SelectedIndex = -1;
            lista.UpdateLayout();

            var container = lista.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
            if (container != null)
            {
                container.Focus();
                lista.ScrollIntoView(lista.Items[0]);
            }
        }

        private bool IsAtRightEdge(ListBoxItem item)
        {
            int index = lstProduct.ItemContainerGenerator.IndexFromContainer(item);
            int itemsPorFila = (int)(lstProduct.ActualWidth / 140);
            if (itemsPorFila <= 0) itemsPorFila = 1;
            return (index + 1) % itemsPorFila == 0 || (index + 1) == lstProduct.Items.Count;
        }
        #endregion


        private void ProcessAction(object element, KeyEventArgs e)
        {
            if (element == txtSearch)
            {
                if (this.DataContext is AlmaceNando.App.ViewModel.SalesViewModel viewModel)
                {
                    if (viewModel.AddFistProductCommand != null)
                    {
                        viewModel.AddFistProductCommand.Execute(null);
                    }
                }

                // Después de agregar, seleccionamos todo. 
                // Así, si el siguiente producto es distinto, solo empieza a escribir y lo viejo se borra.
                txtSearch.SelectAll();

                if (e != null) e.Handled = true;
                return;
            }

            // ... El resto del código de ProcessAction se queda igual (Numeric, Cesta, etc.)
            if (element is TextBox tb && (tb.Name == "PART_TextBox" || tb.TemplatedParent is hc.NumericUpDown))
            {
                FocusSearch();
                if (e != null) e.Handled = true;
                return;
            }
            // ... (mantén tus puntos 3 y 4 de este método como los tienes)
        }



        #region Cesta (Salto al Numeric)
        private void lstCart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCart.SelectedItem == null) return;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                var container = lstCart.ItemContainerGenerator.ContainerFromItem(lstCart.SelectedItem) as FrameworkElement;
                if (container != null)
                {
                    var numeric = FindChild<hc.NumericUpDown>(container);
                    if (numeric != null)
                    {
                        var internalTextBox = FindChild<TextBox>(numeric);
                        if (internalTextBox != null)
                        {
                            internalTextBox.Focus();
                            internalTextBox.SelectAll();
                        }
                    }
                }
            }), System.Windows.Threading.DispatcherPriority.Background);
        }

        private void lstProduct_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(lstProduct, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                item.Focus();
                ProcessAction(item, null);
                e.Handled = true;
            }
        }
        #endregion

        #region Utilidades

        private void ProcessLetter(object element)
        {
            if (element != txtSearch)
            {
                txtSearch.Focus();
            }

            // REGLA DE ORO: Si es espacio, siempre al final. No borra.
            if (Keyboard.IsKeyDown(Key.Space))
            {
                txtSearch.SelectionStart = txtSearch.Text.Length;
                txtSearch.SelectionLength = 0;
            }
            else if (element != txtSearch)
            {
                // Si es una letra y veníamos de afuera, seleccionamos todo
                txtSearch.SelectAll();
            }
        }


        private void ProcessNumber(object element)
        {
            // Evitamos saltar al buscador si estamos en un Numeric o TextBox
            if (element is TextBox || element is hc.NumericUpDown || element == txtSearch) return;
            FocusSearch();
        }

        private void FocusSearch()
        {
            txtSearch.Focus();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Si el usuario dejó un espacio al final, quiere seguir escribiendo.
                // Si no hay espacio, seleccionamos todo para que sea fácil cambiar la búsqueda.
                if (txtSearch.Text.EndsWith(" "))
                {
                    txtSearch.SelectionStart = txtSearch.Text.Length;
                    txtSearch.SelectionLength = 0;
                }
                else
                {
                    txtSearch.SelectAll();
                }
            }
        }
        private bool IsLetter(Key k) => k >= Key.A && k <= Key.Z || Key.Space == k;
        private bool IsNumber(Key k) => (k >= Key.D0 && k <= Key.D9) || (k >= Key.NumPad0 && k <= Key.NumPad9);
        private bool IsArrow(Key k) => k == Key.Up || k == Key.Down || k == Key.Left || k == Key.Right;

        private T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild) return typedChild;
                var result = FindChild<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        #endregion
    }
}
