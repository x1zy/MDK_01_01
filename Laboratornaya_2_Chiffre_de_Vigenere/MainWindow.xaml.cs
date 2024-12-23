using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratornaya_2_Chiffre_de_Vigenere;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void EncryptButton_Click(object sender, RoutedEventArgs e)
    {
        var password = PasswordTextBox.Text;
        var key = KeyTextBox.Text;

        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(key))
        {
            MessageBox.Show("Введите текст и ключ для шифрования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var encryptPassword = new EncryptPassword(password);
        ResultTextBox.Text = encryptPassword.Encrypt(key);
    }

    private void DecryptButton_Click(object sender, RoutedEventArgs e)
    {
        var password = PasswordTextBox.Text;
        var key = KeyTextBox.Text;

        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(key))
        {
            MessageBox.Show("Введите текст и ключ для дешифрования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var encryptPassword = new EncryptPassword(password);
        ResultTextBox.Text = encryptPassword.Decrypt(key);
    }
}