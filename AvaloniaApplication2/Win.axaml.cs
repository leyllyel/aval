using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Xml.Linq;
using System.Xml;

namespace AvaloniaApplication2;

public partial class Win : Window
{
    public Win()
    {
        InitializeComponent();
    }

    public Win(string name)
    {
        InitializeComponent();
        NameWin.Text = $"Добро пожаловать, {name}!";
    }
}