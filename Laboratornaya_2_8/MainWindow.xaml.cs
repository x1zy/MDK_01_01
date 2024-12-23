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

namespace Laboratornaya_2_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод для получения дроби из TextBox
        private bool TryGetFraction(TextBox numBox, TextBox denomBox, out Fraction fraction)
        {
            fraction = null;

            // Парсинг числителя
            if (!int.TryParse(numBox.Text, out int numerator))
            {
                MessageBox.Show("Введите корректный числитель.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Парсинг знаменателя
            if (!int.TryParse(denomBox.Text, out int denominator))
            {
                MessageBox.Show("Введите корректный знаменатель.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            try
            {
                fraction = new Fraction(numerator, denominator);
                return true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка дроби", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Обработчик нажатия кнопки "Вычислить"
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = ""; // Очищаем предыдущие результаты

            // Получаем первую дробь
            if (!TryGetFraction(Fraction1Numerator, Fraction1Denominator, out Fraction f1))
                return;

            // Получаем вторую дробь
            if (!TryGetFraction(Fraction2Numerator, Fraction2Denominator, out Fraction f2))
                return;

            // Выполняем операции и собираем результаты
            string results = "";

            try
            {
                // Сложение
                Fraction sum = f1 + f2;
                results += $"{f1} + {f2} = {sum}\n";

                // Вычитание
                Fraction difference = f1 - f2;
                results += $"{f1} - {f2} = {difference}\n";

                // Умножение
                Fraction product = f1 * f2;
                results += $"{f1} * {f2} = {product}\n";

                // Деление
                Fraction quotient = f1 / f2;
                results += $"{f1} / {f2} = {quotient}\n";
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка деления", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ResultText.Text = results;
        }
    }
}