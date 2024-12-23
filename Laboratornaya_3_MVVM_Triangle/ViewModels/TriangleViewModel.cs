using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratornaya_3_MVVM_Triangle.Model;
using System.ComponentModel;


namespace Laboratornaya_3_MVVM_Triangle.ViewModels
{
    public class TriangleViewModel
    {
        // Вложенный класс ViewModel
        public class ViewModel
        {
            public Triangle Model { get; set; }

            public ViewModel()
            {
                Model = new Triangle();
            }
        }
    }
}
