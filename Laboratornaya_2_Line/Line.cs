using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2_Line
{
    class Line
    {
        double mX1, mY1, mX2, mY2;

        // конструктор
        public Line(double x1, double y1, double x2, double y2)
        {
            mX1 = x1;
            mY1 = y1;
            mX2 = x2;
            mY2 = y2;
        }

        // описание свойств
        public void SetX1(double value)
        {
            mX1 = value;
        }
        public double GetX1()
        {
            return mX1;
        }
        public void SetY1(double value)
        {
            mY1 = value;
        }
        public double GetY1()
        {
            return mY1;
        }
        public void SetX2(double value)
        {
            mX2 = value;
        }
        public double GetX2()
        {
            return mX2;
        }
        public void SetY2(double value)
        {
            mY2 = value;
        }
        public double GetY2()
        {
            return mY2;
        }

        // метод
        public double GetLenght()
        {
            double dx = mX2 - mX1;
            double dy = mY2 - mY1;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    };
}
