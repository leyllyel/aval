using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;

namespace AvaloniaApplication2
{
    public partial class Win : Window
    {
        public Win(ObservableCollection<Product> products)
        {
            InitializeComponent();
            DataContext = products;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}