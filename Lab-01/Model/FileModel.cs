using System;
using System.Drawing;

namespace Lab_01.Model
{
    public class FileModel
    {
        public Icon Icon { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public FileType Type { get; set; }

        public long SizeBytes { get; set; }

        public long FreeSpaceBytes { get; internal set; }
    }
}
