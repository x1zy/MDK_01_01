﻿using System;
using System.Drawing;

namespace Lab_01.Files
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

        public bool IsFile => Type == FileType.File;
        public bool IsFolder => Type == FileType.Folder;
        public bool IsDrive => Type == FileType.Drive;
        public bool IsShortcut => Type == FileType.Shortcut;
    }
}
