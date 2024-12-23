using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.Models;

namespace Example2.ViewModels
{
    public class ViewModel
    {
        public Model Model { get; set; }

        public ViewModel()
        {
            Model = new Model();
        }
    }
}
