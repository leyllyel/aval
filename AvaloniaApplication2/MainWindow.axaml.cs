using Avalonia.Controls;
using Avalonia.Dialogs;
using Xunit.Sdk;

namespace AvaloniaApplication2;

public partial class MainWindow : Window
{
    private const string CorrectLogin = "admin";
    private const string CorrectPassword = "password123";
    public MainWindow()
    {
        InitializeComponent();
    }


 
    private void Button_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string login = LoginBox.Text;
        string password = PasswordBox.Text;

        if (password == CorrectPassword)
        {
            var win = new Win(login);
            win.Show();
            Close();
        }
        else
        {
            ErrorMessage.Text = "Неверный пароль!";
        }
    }
}