using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Laboratornaya_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultTextBox.Text = "Введите длины сторон треугольника и нажмите 'Вычислить'.";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Парсинг введенных значений
            if (!double.TryParse(SideATextBox.Text, out double a) ||
                !double.TryParse(SideBTextBox.Text, out double b) ||
                !double.TryParse(SideCTextBox.Text, out double c))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для всех сторон.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (a <= 0 || b <= 0 || c <= 0)
            {
                MessageBox.Show("Длины сторон должны быть положительными числами.", "Неверные значения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание объекта IsoscelesTriangle
            IsoscelesTriangle triangle = new IsoscelesTriangle(a, b, c);

            // Проверка существования треугольника
            if (!triangle.IsValid())
            {
                ResultTextBox.Text = "Треугольник с заданными сторонами не существует.";
                return;
            }

            // Получение информации о треугольнике
            string info = triangle.GetInfo();
            ResultTextBox.Text = info;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Разрешаем только цифры и запятую
            Regex regex = new Regex("[^0-9,]+"); // Только цифры и запятая
            e.Handled = regex.IsMatch(e.Text); // Блокируем ввод, если символ не соответствует
        }
    }
}
