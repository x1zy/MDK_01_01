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

namespace Check
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Словарь хранящий имя файла и время его открытия
        private Dictionary<string, DateTime> files = new Dictionary<string, DateTime>();
        public MainWindow()
        {
            InitializeComponent();
            DisksInitialization();
            this.Closing += CloseMainWindow; // Привязка закрытия окна
        }

        // Получение списка дисков
        private void DisksInitialization()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                disksList.Items.Add(drive.Name);
            }
        }

        // Получение информации о дисках
        private void ShowDiskInfo(object sender, SelectionChangedEventArgs e)
        {
            string selectedDisk = (string)disksList.SelectedItem;
            DriveInfo drive = new DriveInfo(selectedDisk);

            if (drive.IsReady)
            {
                diskName.Text = selectedDisk;
                freeSpaceProgress.Minimum = 0;
                freeSpaceProgress.Maximum = drive.TotalSize;
                freeSpaceProgress.Value = drive.TotalFreeSpace;
                freeSpaceText.Text = $"{drive.TotalFreeSpace / 1024 / 1024 / 1024} ГБ свободно из {drive.TotalSize / 1024 / 1024 / 1024} ГБ";
                ShowListCatalogs(selectedDisk);
            }
            else
            {
                diskName.Text = "Диск не доступен";
                freeSpaceProgress.Value = 0;
                freeSpaceText.Text = "Информация не доступна";
            }
        }

        // Отображение каталогов
        private void ShowListCatalogs(string selectedDisk)
        {
            string dirName = selectedDisk;
            if (Directory.Exists(dirName))
            {
                catalogsList.Items.Clear();
                filesList.Items.Clear();
                string[] dirs = Directory.GetDirectories(dirName);
                if (dirs.All(string.IsNullOrEmpty))
                {
                    catalogsList.Items.Add("Каталогов не найдено");
                }
                else
                {
                    foreach (string dir in dirs)
                    {
                        catalogsList.Items.Add(dir);
                    }
                }
            }
        }

        // Отображение файлов
        private void ShowListFiles(object sender, SelectionChangedEventArgs e)
        {
            string dirName = (string)catalogsList.SelectedItem;
            if (Directory.Exists(dirName))
            {
                try
                {
                    ShowCatalogInfo(dirName);
                    filesList.Items.Clear();
                    string[] files = Directory.GetFiles(dirName);
                    if (files.All(string.IsNullOrEmpty))
                    {
                        filesList.Items.Add("Файлы не найдены");
                    }
                    else
                    {
                        foreach (string file in files)
                        {
                            filesList.Items.Add(file);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    filesList.Items.Add("Нет доступа к каталогу");
                }
            }
        }

        // Отображение информации о каталогах
        private void ShowCatalogInfo(string _dirName)
        {
            string dirName = _dirName;
            if (Directory.Exists(dirName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                fullNameCatalog.Text = $"Полное название каталога: {dirInfo.FullName}";
                dateCreation.Text = $"Время создания каталога: {dirInfo.CreationTime}";
                rootCatalog.Text = $"Корневой каталог: {dirInfo.Root}";
            }
        }

        // Открытие файлов
        private void OpenFile(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateTimeOpen = DateTime.Now;
            string path = (string)filesList.SelectedItem;
            if (filesList.SelectedItem != null)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = path,
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                        UpdateData(path, dateTimeOpen);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Не удалось открыть файл");
                    }
                }
                else
                {
                    MessageBox.Show("Файл не найден");
                }
            }
        }

        // Добавление открытого файла в словарь
        private void UpdateData(string _path, DateTime _dateTime)
        {
            string path = _path;
            DateTime dateTime = _dateTime;
            if (!files.ContainsKey(_path))
            {
                files.Add(path, dateTime);
            }
            else
            {
                files[path] = dateTime;
            }
        }

        // Добавление файлов в txt
        private void SaveData()
        {
            DateTime dateTimeClosed = DateTime.Now;
            string filePath = "C://output.txt";

            using (FileStream fileStream = File.Open(filePath, FileMode.Create))
            {
                using (StreamWriter output = new StreamWriter(fileStream))
                {
                    foreach (var file in files)
                    {
                        TimeSpan difference = dateTimeClosed - file.Value;
                        double secondsDifference = difference.TotalSeconds;

                        if (secondsDifference <= 10)
                        {
                            output.WriteLine(file.Key + " Время открытия файла: " + file.Value);
                        }
                    }
                    output.WriteLine($"Время закрытия программы: {dateTimeClosed}");
                }
            }
        }

        // Метод перехвата закрытия окна
        private void CloseMainWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveData();
        }

    }
}