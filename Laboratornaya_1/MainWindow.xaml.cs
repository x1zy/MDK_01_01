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
using Laboratornaya_1.ViewModels;
namespace Laboratornaya_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainVm;

        public MainWindow()
        {
            InitializeComponent();

            _mainVm = new MainViewModel();

            DataContext = _mainVm;
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainVm.ApplicationClosing();

            Application.Current.Shutdown();
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
        }

        private void CollapseButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}