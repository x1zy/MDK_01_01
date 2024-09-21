using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.Entities
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string name) : base(name)
        {
        }

        public FileViewModel(FileInfo fileInfo) : base(fileInfo.Name)
        {
            FullName = fileInfo.FullName;
        }


    }
}
