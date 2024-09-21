using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.History
{
    internal interface IDirectoryHistory : IEnumerable<DirectoryNode>
    {
        bool CanMoveBack { get; }

        bool CanMoveForward { get; }

        DirectoryNode Current { get; }

        event EventHandler HistoryChanged;

        void MoveBack();

        void MoveForward();

        void Add(string filePath, string name);
    }

    internal class DirectoryNode
    {
        public DirectoryNode PreviousNode { get; set; }
        public DirectoryNode NextNode { get; set; }

        public string DirectoryPath { get; }
        public string DirectoryPathName { get; }

        public DirectoryNode(string directoryPath, string directoryPathName)
        {
            DirectoryPath = directoryPath;
            DirectoryPathName = directoryPathName;
        }
    }
}
