using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;

namespace AvaloniaApplication2;

public partial class EditProductWindow : Window
{
    private readonly Product _product;
    private readonly ObservableCollection<Product> _products;

    public EditProductWindow(Product product, ObservableCollection<Product> products)
    {
        InitializeComponent();
        _product = product;
        _products = products;
        EditNameBox.Text = _product.Name;
        EditPriceBox.Text = _product.Price.ToString();
    }

    private void OnEditClick(object sender, RoutedEventArgs e)
    {
        string name = EditNameBox.Text;
        string priceInput = EditPriceBox.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            ShowErrorMessage("¬ведите название продукта!");
            return;
        }

        if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
        {
            ShowErrorMessage("¬ведите корректную цену (положительное число)!");
            return;
        }

        _product.Name = name;
        _product.Price = price;


        Win win = new Win(_products);
        win.Show();
        Close();
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