using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Example2.Models
{

    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double length;
        public double Length
        {
            get { return length; }
            set
            {
                if (value > 0)
                {
                    length = value;
                    
                    OnPropertyChanged(nameof(Sq)); // уведомление View о том, что изменилась площадь
                }
            }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                    
                    OnPropertyChanged(nameof(Sq)); // уведомление View о том, что изменилась площадь
                }
            }
        }

        public double Sq
        {
            get { return width * length; }
        }
        
    }
}