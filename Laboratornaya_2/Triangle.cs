using System;

namespace TriangleApp
{
    public class Triangle
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // Проверка существования треугольника
        public bool IsValid()
        {
            return (SideA + SideB > SideC) &&
                   (SideA + SideC > SideB) &&
                   (SideB + SideC > SideA);
        }

        // Вычисление периметра
        public double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        // Вычисление площади (формула Герона)
        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        // Вычисление углов в градусах
        public (double AngleA, double AngleB, double AngleC) GetAngles()
        {
            double angleA = Math.Acos((Math.Pow(SideB, 2) + Math.Pow(SideC, 2) - Math.Pow(SideA, 2)) / (2 * SideB * SideC)) * (180 / Math.PI);
            double angleB = Math.Acos((Math.Pow(SideA, 2) + Math.Pow(SideC, 2) - Math.Pow(SideB, 2)) / (2 * SideA * SideC)) * (180 / Math.PI);
            double angleC = 180 - angleA - angleB;
            return (angleA, angleB, angleC);
        }

        // Получение сведений о треугольнике
        public string GetInfo()
        {
            if (!IsValid())
                return "Треугольник не существует.";

            var angles = GetAngles();
            return $"Стороны: a = {SideA}, b = {SideB}, c = {SideC}\n" +
                   $"Углы: A = {angles.AngleA:F2}°, B = {angles.AngleB:F2}°, C = {angles.AngleC:F2}°\n" +
                   $"Периметр: {GetPerimeter()}\n" +
                   $"Площадь: {GetArea():F2}";
        }
    }
}
