using Lab_01.Files;
using Lab_01.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;

namespace Lab_01.Explorer
{
    public static class Fetcher
    {
        public static List<FileModel> GetFiles(string directory)
        {
            List<FileModel> files = new List<FileModel>();

            if (!directory.IsDirectory())
                return files;

            // для работы с исключениями
            string currentFile = "";

            // код для получения всех файлов
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    currentFile = file;

                    if (Path.GetExtension(file) != ".lnk")
                    {
                        FileInfo fInfo = new FileInfo(file);
                        FileModel fModel = new FileModel()
                        {
                            Icon = IconHelper.GetIconOfFile(file, true, false),
                            Name = fInfo.Name,
                            Path = fInfo.FullName,
                            DateCreated = fInfo.CreationTime,
                            DateModified = fInfo.LastWriteTime,
                            Type = FileType.File,
                            SizeBytes = fInfo.Length
                        };

                        files.Add(fModel);
                    }
                }

                return files;
            }

            catch (IOException io)
            {
                MessageBox.Show(
                    $"IO Исключение при получении файлов в каталоге {io.Message}",
                    "Исключение при получении файлов в каталоге");
            }
            catch (UnauthorizedAccessException noAccess)
            {
                MessageBox.Show(
                    $"Нет доступа к файлу: {noAccess.Message}",
                    "Исключение при получении файлов в каталоге");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Не удалось получить файлы в '{directory}' || " +
                    $"Что-то с '{currentFile}'\n" +
                    $"Исключение: {e.Message}", "Error");
            }

            return files;
        }

        public static List<FileModel> GetDirectories(string directory)
        {
            List<FileModel> directories = new List<FileModel>();

            if (!directory.IsDirectory())
                return directories;

            string currentDirectory = "";

            try
            {
                // проверяем наличие обычных каталогов
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    currentDirectory = dir;

                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    FileModel dModel = new FileModel()
                    {
                        Icon = IconHelper.GetIconOfFile(dir, true, true),
                        Name = dInfo.Name,
                        Path = dInfo.FullName,
                        DateCreated = dInfo.CreationTime,
                        DateModified = dInfo.LastWriteTime,
                        Type = FileType.Folder,
                        SizeBytes = long.MaxValue
                    };

                    directories.Add(dModel);
                }

                // проверяет наличие ярлыков в каталогах
                foreach (string file in Directory.GetFiles(directory))
                {
                    if (Path.GetExtension(file) == ".lnk")
                    {
                        string realDirPath = ExplorerHelpers.GetShortcutTargetFolder(file);
                        FileInfo dInfo = new FileInfo(realDirPath);
                        FileModel dModel = new FileModel()
                        {
                            Icon = IconHelper.GetIconOfFile(realDirPath, true, true),
                            Name = dInfo.Name,
                            Path = dInfo.FullName,
                            DateCreated = dInfo.CreationTime,
                            DateModified = dInfo.LastWriteTime,
                            Type = FileType.Folder,
                            SizeBytes = 0
                        };

                        directories.Add(dModel);
                    }
                }

                return directories;
            }

            catch (IOException io)
            {
                MessageBox.Show(
                    $"IO Исключение при получении папок в каталоге:  {io.Message}",
                    "Исключение при получении папок в каталоге»");
            }
            catch (UnauthorizedAccessException noAccess)
            {
                MessageBox.Show(
                    $"Нет доступа к каталогу: {noAccess.Message}",
                    "Исключение при получении папок в каталоге");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $"Не удалось получить каталоги в '{directory}' || " +
                    $"Что-то связанное с '{currentDirectory}'\n" +
                    $"Исключение: {e.Message}", "Ошибка");
            }

            return directories;
        }

        public static List<FileModel> GetDrives()
        {
            List<FileModel> drives = new List<FileModel>();

            try
            {

                foreach (string drive in Directory.GetLogicalDrives())
                {
                    DriveInfo dInfo = new DriveInfo(drive);

                    if (dInfo.IsReady)  // проверяем, доступен ли диск
                    {
                        FileModel dModel = new FileModel()
                        {
                            Icon = IconHelper.GetIconOfFile(drive, true, true),
                            Name = dInfo.Name,
                            Path = dInfo.Name,
                            DateModified = DateTime.Now,
                            Type = FileType.Drive,
                            SizeBytes = dInfo.TotalSize,
                            FreeSpaceBytes = dInfo.AvailableFreeSpace
                        };

                        drives.Add(dModel);
                    }
                }

                return drives;
            }

            catch (IOException io)
            {
                MessageBox.Show($"IO Исключение при получении дисков: {io.Message}", "Исключение при получении дисков");
            }
            catch (UnauthorizedAccessException noAccess)
            {
                MessageBox.Show($"Нет доступа к жесткому диску: {noAccess.Message}");
            }

            return drives;
        }
    }
}
