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

namespace Laboratornaya_2_Password;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Заданный программистом пароль
    private readonly string presetPassword = "SecurePass123!";

    public MainWindow()
    {
        InitializeComponent();
        ResultTextBox.Text = "Введите пароль и нажмите 'Проверить пароль' или зарегистрируйтесь.";
    }
    
    // Обработчик кнопки регистрации
    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        string inputPassword = PasswordBox.Password;
        string firstName = FirstNameTextBox.Text.Trim();
        string lastName = LastNameTextBox.Text.Trim();
        string birthDate = BirthDateTextBox.Text.Trim();
        string nickname = NicknameTextBox.Text.Trim();

        // Валидация личной информации
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(birthDate) || string.IsNullOrEmpty(nickname))
        {
            MessageBox.Show("Пожалуйста, заполните все поля личной информации.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Проверка формата даты рождения (ДДММГГ)
        if (!IsValidBirthDate(birthDate))
        {
            MessageBox.Show("Дата рождения должна быть в формате ДДММГГ (например, 010190).", "Неверный формат", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Проверка на совпадение с заданным паролем
        if (inputPassword == presetPassword)
        {
            ResultTextBox.Text = "Пароль верный.";
            return;
        }

        // Создание объекта SecurePassword и проверка надежности пароля
        SecurePassword securePassword = new SecurePassword(inputPassword, firstName, lastName, birthDate, nickname);
        bool isStrongPassword = securePassword.AnalyzeStrength();

        // Установка текста в ResultTextBox в зависимости от надежности
        ResultTextBox.Text = isStrongPassword ? "Пароль надежный" : "Пароль ненадежный";
    }


    // Метод проверки формата даты рождения
    private bool IsValidBirthDate(string birthDate)
    {
        if (birthDate.Length != 6)
            return false;

        foreach (char c in birthDate)
        {
            if (!char.IsDigit(c))
                return false;
        }

        // Дополнительные проверки на корректность даты можно добавить здесь

        return true;
    }
}