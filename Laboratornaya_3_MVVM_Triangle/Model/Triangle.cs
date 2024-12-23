using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_3_MVVM_Triangle.Model
{
    public class Triangle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double _sideA;
        private double _sideB;
        private double _sideC;
        private string _result;

        public double SideA
        {
            get { return _sideA; }
            set
            {
                if (_sideA != value)
                {
                    _sideA = value;
                    OnPropertyChanged(nameof(SideA));
                    UpdateResult();
                }
            }
        }

        public double SideB
        {
            get { return _sideB; }
            set
            {
                if (_sideB != value)
                {
                    _sideB = value;
                    OnPropertyChanged(nameof(SideB));
                    UpdateResult();
                }
            }
        }

        public double SideC
        {
            get { return _sideC; }
            set
            {
                if (_sideC != value)
                {
                    _sideC = value;
                    OnPropertyChanged(nameof(SideC));
                    UpdateResult();
                }
            }
        }

        public string Result
        {
            get { return _result; }
            private set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public Triangle()
        {
        }

        private void UpdateResult()
        {
            // Проверка на допустимые значения
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                Result = "Ошибка: длины сторон должны быть положительными числами.";
                return;
            }

            if (!IsValid())
            {
                Result = "Треугольник не существует.";
                return;
            }

            Result = $"Стороны: {SideA}, {SideB}, {SideC}\n" +
                     $"Периметр: {GetPerimeter()}\n" +
                     $"Площадь: {GetArea()}\n" +
                     $"Углы: {string.Join(", ", GetAngles())}\n" +
                     $"Равнобедренный: {(IsIsosceles() ? "Да" : "Нет")}";
        }

        public bool IsValid()
        {
            return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
        }

        public double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public double[] GetAngles()
        {
            double a = SideA, b = SideB, c = SideC;
            double angleA = Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180 / Math.PI;
            double angleB = Math.Acos((a * a + c * c - b * b) / (2 * a * c)) * 180 / Math.PI;
            double angleC = 180 - angleA - angleB;
            return new double[] { angleA, angleB, angleC };
        }

        public bool IsIsosceles()
        {
            return SideA == SideB || SideA == SideC || SideB == SideC;
        }
    }
}
