using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.Entities
{
    public sealed class DirectoryViewModel : FileEntityViewModel
    {
        public DirectoryViewModel(string directoryName) : base(directoryName)
        {
            FullName = directoryName;
        }

        public DirectoryViewModel(DirectoryInfo directoryName) : base(directoryName.Name)
        {
            FullName = directoryName.FullName;
        }
    }
}
