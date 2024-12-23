using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace lab_01
{
    public partial class MainWindow : Window
    {
        private DriveInfo[] drives = DriveInfo.GetDrives();
        private List<Tuple<DateTime, string>> openedApps = new List<Tuple<DateTime, string>>();

        public MainWindow()
        {
            LoadDrives();
        }

        private void LoadDrives()
        {
            DrivesComboBox.ItemsSource = drives.Select(d => d.Name).ToList();
            DrivesComboBox.SelectedIndex = 0;
            FoldersListBox.Items.Add("Выберите каталог");
        }

        private string[] GetDirectoriesAndFiles(string path)
        {
            List<string> items = new List<string>();
            items.AddRange(Directory.GetDirectories(path));
            items.AddRange(Directory.GetFiles(path));
            return items.ToArray();
        }

        private string GetFormatSize(long size)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = size;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        private void DrivesComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DrivesComboBox.SelectedItem != null)
            {
                DriveInfo selectedDrive = drives[DrivesComboBox.SelectedIndex];
                FoldersListBox.Items.Clear();
                FoldersListBox.Items.AddRange(GetDirectoriesAndFiles(selectedDrive.Name));

                DriveInfoText.Text =
                    $"Общий объем: {GetFormatSize(selectedDrive.TotalSize)}\n" +
                    $"Свободное пространство: {GetFormatSize(selectedDrive.AvailableFreeSpace)}";
            }
        }

        private void FoldersListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FoldersListBox.SelectedItem != null)
            {
                string dirName = FoldersListBox.SelectedItem.ToString();
                FilesListBox.Items.Clear();
                FilesListBox.Items.AddRange(GetDirectoriesAndFiles(dirName));

                DirectoryInfo selectedDirectory = new DirectoryInfo(dirName);
                FolderInfoText.Text =
                    $"Полное имя: {selectedDirectory.FullName}\n" +
                    $"Время создания: {selectedDirectory.CreationTime}\n" +
                    $"Корневой каталог: {selectedDirectory.Root}";
            }
        }

        private void FilesListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FilesListBox.SelectedItem != null)
            {
                string filePath = FilesListBox.SelectedItem.ToString();
                SaveOpened(filePath);
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
        }

        private void SaveOpened(string path)
        {
            openedApps.Add(new Tuple<DateTime, string>(DateTime.Now, path));
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            string recentFiles = string.Join(Environment.NewLine, openedApps
                .Where(item => item.Item1.AddSeconds(10) > DateTime.Now)
                .Select(item => item.Item2));

            File.WriteAllText("output.txt", recentFiles);
        }
    }
}   