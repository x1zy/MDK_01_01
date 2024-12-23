using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_3_MVVM_Triangle.Model
{
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double sideA, double sideB, double sideC) : base(sideA, sideB, sideC)
        {
        }

        public bool IsIsosceles()
        {
            return SideA == SideB || SideA == SideC || SideB == SideC;
        }
    }
}
