using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Labor_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Массив доступных дисков
        private readonly DriveInfo[] _drives = DriveInfo.GetDrives();

        // Список открытых файлов с временем открытия
        private readonly List<Tuple<DateTime, string>> _openedFiles = new List<Tuple<DateTime, string>>();

        // Путь к лог-файлу
        private readonly string _logFilePath = @"C:\Users\Mi\Documents\recentFiles.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadDrives();

            // Очищаем лог-файл и записываем время запуска программы
            LogProgramStart();

            this.Closed += App_Closed;
        }

        /// <summary>
        /// Загружает доступные диски в ComboBox.
        /// </summary>
        private void LoadDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                DrivesComboBox.Items.Add(drive.Name);
            }
        }

        /// <summary>
        /// Получает список директорий из указанного пути.
        /// </summary>
        /// <param name="path">Путь к директории.</param>
        /// <returns>Список директорий.</returns>
        private List<string> GetDirectories(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return Directory.GetDirectories(path).ToList();
                }
                else
                {
                    MessageBox.Show($"Путь не существует: {path}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Отказано в доступе к директории: {path}");
            }
            return new List<string>();
        }

        /// <summary>
        /// Получает список файлов из указанного пути.
        /// </summary>
        /// <param name="path">Путь к директории.</param>
        /// <returns>Список файлов.</returns>
        private List<string> GetFiles(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    return Directory.GetFiles(path).ToList();
                }
                else
                {
                    MessageBox.Show($"Путь не существует: {path}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Ошибка при получении файлов");
            }
            return new List<string>();
        }

        /// <summary>
        /// Форматирует размер из байт в удобочитаемый формат.
        /// </summary>
        /// <param name="size">Размер в байтах.</param>
        /// <returns>Отформатированная строка размера.</returns>
        private static string GetFormattedSizeForDrivers(long size)
        {
            const int scale = 1024;
            string[] sizes = { "Б", "КБ", "МБ", "ГБ", "ТБ" };

            double len = size;
            int order = 0;

            // Определяем порядок величины
            while (len >= scale && order < sizes.Length - 1)
            {
                order++;
                len /= scale;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        /// <summary>
        /// Обработчик изменения выбора в ComboBox дисков.
        /// </summary>
        private void DrivesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDrive = DrivesComboBox.SelectedItem.ToString();
            var directories = GetDirectories(selectedDrive);

            FoldersListBox.Items.Clear();
            FilesListBox.Items.Clear();

            foreach (var dir in directories)
            {
                FoldersListBox.Items.Add(dir);
            }

            // Обновляем информацию о диске
            DriveInfo selectedDriveInfo = _drives[DrivesComboBox.SelectedIndex];
            DriveInfoText.Text =
                $"Общий объем: {GetFormattedSizeForDrivers(selectedDriveInfo.TotalSize)}\n" +
                $"Свободное пространство: {GetFormattedSizeForDrivers(selectedDriveInfo.AvailableFreeSpace)}";
        }

        /// <summary>
        /// Обработчик изменения выбора каталогов и обновление информации при одном клике.
        /// </summary>
        private void FoldersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FoldersListBox.SelectedItem == null ||
                FoldersListBox.SelectedItem.ToString() == "Нет элементов")
                return;

            string selectedPath = FoldersListBox.SelectedItem.ToString();

            // Обновляем информацию о выбранной директории
            DisplayDirectoryInfo(selectedPath);
        }

        /// <summary>
        /// Обработчик двойного клика по элементу в списке каталогов.
        /// Отображает поддиректории и файлы выбранного каталога.
        /// </summary>
        private void FoldersListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FoldersListBox.SelectedItem == null ||
                FoldersListBox.SelectedItem.ToString() == "Нет элементов")
                return;

            string selectedPath = FoldersListBox.SelectedItem.ToString();
            var directories = GetDirectories(selectedPath);
            var files = GetFiles(selectedPath);

            FoldersListBox.Items.Clear();
            FilesListBox.Items.Clear();

            if (directories.Count != 0)
            {
                foreach (var dir in directories)
                {
                    FoldersListBox.Items.Add(dir);
                }
            }
            else
            {
                FoldersListBox.Items.Add("Нет элементов");
            }

            if (files.Count != 0)
            {
                foreach (var file in files)
                {
                    FilesListBox.Items.Add(file);
                }
            }
            else
            {
                FilesListBox.Items.Add("Файлы отсутствуют");
            }

            DisplayDirectoryInfo(selectedPath);
        }

        /// <summary>
        /// Отображает информацию о выбранной директории.
        /// </summary>
        /// <param name="path">Путь к директории.</param>
        private void DisplayDirectoryInfo(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FolderInfoText.Text =
                $"Полное имя: {dirInfo.FullName}\n" +
                $"Время создания: {dirInfo.CreationTime}\n" +
                $"Корневой каталог: {dirInfo.Root}";
        }

        /// <summary>
        /// Обработчик двойного клика по элементу в списке файлов.
        /// Открывает выбранный файл с помощью ассоциированного приложения.
        /// </summary>
        private void FilesListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (FilesListBox.SelectedItem == null ||
                FilesListBox.SelectedItem.ToString() == "Файлы отсутствуют")
                return;
            string filePath = FilesListBox.SelectedItem.ToString();
            OpenFile(filePath);
        }

        /// <summary>
        /// Открывает файл и сохраняет информацию о нем.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        private void OpenFile(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                DateTime openTime = DateTime.Now;

                // Сохраняем информацию о времени открытия файла
                _openedFiles.Add(new Tuple<DateTime, string>(openTime, path));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл: {ex.Message}");
            }
        }

        /// <summary>
        /// Записывает время запуска программы в лог-файл.
        /// Очищает предыдущие записи.
        /// </summary>
        private void LogProgramStart()
        {
            string startTime = $"Время запуска программы: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}\n\n";

            try
            {
                // Очищаем файл и записываем время запуска
                File.WriteAllText(_logFilePath, startTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обработчик закрытия окна приложения.
        /// Сохраняет имена файлов, открытых за последние 10 секунд, в текстовый файл.
        /// </summary>
        private void App_Closed(object sender, EventArgs e)
        {
            DateTime threshold = DateTime.Now.AddSeconds(-10);
            var recentFiles = _openedFiles
                .Where(file => file.Item1 >= threshold)
                .ToList();

            try
            {
                using (StreamWriter writer = new StreamWriter(_logFilePath, true))
                {
                    writer.WriteLine("Файлы, запущенные за последние 10 секунд:");

                    if (recentFiles.Count != 0)
                    {
                        foreach (var file in recentFiles)
                        {
                            string openTime = file.Item1.ToString("dd.MM.yyyy HH:mm:ss");
                            writer.WriteLine($"Файл: {file.Item2}, открыт в {openTime}");
                        }
                    }
                    else
                    {
                        writer.WriteLine("Нет запущенных файлов за последние 10 секунд.");
                    }

                    writer.WriteLine($"\nВремя закрытия программы: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Опционально: Очистить список открытых файлов
            _openedFiles.Clear();
        }
    }
}
