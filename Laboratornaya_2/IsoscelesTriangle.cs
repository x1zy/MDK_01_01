using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleApp;

namespace Laboratornaya_2
{
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double sideA, double sideB, double sideC)
            : base(sideA, sideB, sideC)
        {
        }

        // Проверка на равнобедренность
        public bool IsIsosceles()
        {
            return (SideA == SideB) || (SideA == SideC) || (SideB == SideC);
        }

        // Вывод информации о равнобедренности
        public new string GetInfo()
        {
            string baseInfo = base.GetInfo();
            if (!IsValid())
                return baseInfo;

            string isoscelesInfo = IsIsosceles() ? "Треугольник равнобедренный." : "Треугольник не является равнобедренным.";
            return $"{baseInfo}\n{isoscelesInfo}";
        }
    }
}
