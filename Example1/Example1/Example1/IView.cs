using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    internal interface IView
    {
        string Sq { get; set; }
        double InputA { get; set; }
        double InputB { get; set; }

        // Событие ввода значения 
        event EventHandler<EventArgs> SetA;
        // Событие ввода значения 
        event EventHandler<EventArgs> SetB;

    }
}
