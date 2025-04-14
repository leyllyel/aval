using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace AvaloniaApplication2
{
    public partial class Win : Window
    {
        public ObservableCollection<Product> Products { get; }

        public Win(ObservableCollection<Product> products)
        {
            InitializeComponent();
            Products = products;
            DataContext = this;
        }

        private void OnProductSelected(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Product product)
            {
                var editWindow = new EditProductWindow(product, Products);
                editWindow.ShowDialog(this);
                
            }
        }
    }
}
