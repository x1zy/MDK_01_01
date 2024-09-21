using Lab_01.Explorer;
using Lab_01.Model;
using Lab_01.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab_01.Services.Commands;
using System.IO;

namespace Lab_01.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<FilesControl> FileItems { get; set; }
        private readonly IDirectoryHistory _directoryHistory;

        public MainViewModel()
        {
            FileItems = new ObservableCollection<FilesControl>();
            _directoryHistory = new DirectoryHistory("rootPath", "Root");

            NavigateBackCommand = new RelayCommand(MoveBack, (param) => _directoryHistory.CanMoveBack);
            NavigateForwardCommand = new RelayCommand(MoveForward, (param) => _directoryHistory.CanMoveForward);
            _directoryHistory.HistoryChanged += (s, e) =>
            {
                (NavigateBackCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (NavigateForwardCommand as RelayCommand)?.RaiseCanExecuteChanged();
            };

            // Загружаем корневые директории при инициализации
            LoadFilesFromPath("");
        }

        public RelayCommand NavigateBackCommand { get; }
        public RelayCommand NavigateForwardCommand { get; }

        private void MoveBack(object param)
        {
            if (_directoryHistory.CanMoveBack)
            {
                _directoryHistory.MoveBack();
                LoadFilesFromPath(_directoryHistory.Current.DirectoryPath);
            }
        }

        private void MoveForward(object param)
        {
            if (_directoryHistory.CanMoveForward)
            {
                _directoryHistory.MoveForward();
                LoadFilesFromPath(_directoryHistory.Current.DirectoryPath);
            }
        }

        public void LoadFilesFromPath(string path)
        {
            ClearFiles();

            if (string.IsNullOrEmpty(path))
            {
                foreach (var drive in Fetcher.GetDrives())
                {
                    AddFile(CreateFileControl(drive));
                }
            }
            else if (path.IsDirectory())
            {
                foreach (var dir in Fetcher.GetDirectories(path))
                {
                    AddFile(CreateFileControl(dir));
                }

                foreach (var file in Fetcher.GetFiles(path))
                {
                    AddFile(CreateFileControl(file));
                }
            }
            else if (path.IsFile())
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }

            _directoryHistory.Add(path, Path.GetFileName(path));
        }

        public void AddFile(FilesControl file)
        {
            FileItems.Add(file);
        }

        public void ClearFiles()
        {
            FileItems.Clear();
        }

        private FilesControl CreateFileControl(FileModel fileModel)
        {
            var fileControl = new FilesControl(fileModel);
            fileControl.NavigateToPathCallback = NavigateFromModel;
            return fileControl;
        }

        private void NavigateFromModel(FileModel fileModel)
        {
            LoadFilesFromPath(fileModel.Path);
        }
    }

}