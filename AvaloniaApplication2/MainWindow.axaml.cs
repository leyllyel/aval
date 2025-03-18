using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace AvaloniaApplication2
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ProductsListBox.ItemsSource = Products;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(PriceBox.Text, out decimal price))
            {
                Products.Add(new Product
                {
                    Name = NameBox.Text,
                    Price = price
                });

                NameBox.Clear();
                PriceBox.Clear();
            }
        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            var productsWindow = new Win(Products);
            productsWindow.Show();
        }
    }
}