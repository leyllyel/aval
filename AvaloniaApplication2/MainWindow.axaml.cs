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
            string countInput = CountBox.Text;




            if (string.IsNullOrWhiteSpace(name))
            {
                ShowErrorMessage("������� �������� ��������!");
                return;
            }

            if (!decimal.TryParse(priceInput, out decimal price) || price < 0)
            {
                ShowErrorMessage("������� ���������� ����");
                return;
            }
            if (!int.TryParse(countInput, out int count) || count < 0)
            {
                ShowErrorMessage("������� ���������� ���������� ������");
                return;
            }


            products.Add(new Product { Name = name, Price = price, Count = count });

            NameBox.Text = "";
            PriceBox.Text = "";
            CountBox.Text = "";
        }

        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            new Win(products).Show();
            this.Close();
        }

        private void ShowErrorMessage(string message)
        {
            var dialog = new Window
            {
                Title = "������",
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