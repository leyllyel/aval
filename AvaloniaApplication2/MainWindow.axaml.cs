using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace AvaloniaApplication2
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> products = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text;
            string priceInput = PriceBox.Text;

            
            if (string.IsNullOrWhiteSpace(name))
            {
                ShowErrorMessage("¬ведите название продукта!");
                return;
            }

            if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
            {
                ShowErrorMessage("¬ведите корректную цену");
                return;
            }

      
            products.Add(new Product { Name = name, Price = price });

            NameBox.Text = "";
            PriceBox.Text = "";
        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            new Win(products).Show();
        }

        private void ShowErrorMessage(string message)
        {
            var dialog = new Window
            {
                Title = "ќшибка",
                Width = 300,
                Height = 150,
                Content = new TextBlock
                {
                    Text = message,
                    TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                    Margin = new Avalonia.Thickness(10)
                }
            };
            dialog.ShowDialog(this);
        }
    }
}