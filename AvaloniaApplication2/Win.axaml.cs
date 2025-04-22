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
        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedProduct = button.DataContext as Product;
                if (selectedProduct != null)
            {
                var editWindow = new EditProductWindow(selectedProduct, Products);
                editWindow.Show();
                Close();
            }
        }
        private void AddDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var selectedProduct = button.DataContext as Product;
            if (selectedProduct != null)
            {
                Products.Remove(selectedProduct);
            }
        }
        private void BackClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
  }

