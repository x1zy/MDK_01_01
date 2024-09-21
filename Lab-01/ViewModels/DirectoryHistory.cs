using System.Windows;

namespace Lab_01.ViewModels
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        #region Private Fields

        private DirectoryNode _head;

        #endregion

        #region Properties

        public bool CanMoveBack => Current.PreviousNode != null;
        public bool CanMoveForward => Current.NextNode != null;

        public DirectoryNode Current { get; private set; }

        #endregion

        #region Events

        public event EventHandler HistoryChanged;

        #endregion

        #region Constructor

        public DirectoryHistory(string directoryPath, string directoryPathName)
        {
            _head = new DirectoryNode(directoryPath, directoryPathName);
            Current = _head;
        }

        #endregion

        #region Public Methods

        public void MoveBack()
        {
            if (CanMoveBack)
            {
                Current = Current.PreviousNode;
                RaiseHistoryChanged();
            }
            else
            {
                MessageBox.Show("Cannot move back");
            }
        }

        public void MoveForward()
        {
            if (CanMoveForward)
            {
                MessageBox.Show($"Moving forward to: {Current.NextNode?.DirectoryPath}");
                Current = Current.NextNode;
                RaiseHistoryChanged();
            }
            else
            {
                MessageBox.Show("Cannot move forward");
            }
        }

        public void Add(string filePath, string name)
        {
            MessageBox.Show($"Adding directory to history: {filePath}");
            var node = new DirectoryNode(filePath, name)
            {
                PreviousNode = Current,
                NextNode = null
            };

            if (Current != null)
            {
                Current.NextNode = node;
            }

            Current = node;
            RaiseHistoryChanged();
        }

        #endregion

        #region Private Methods

        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Enumerator

        public IEnumerator<DirectoryNode> GetEnumerator()
        {
            yield return Current;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
