using System;

namespace Laboratornaya_3_Fractions_WindowsForms
{
    internal class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator { get { return numerator; } set { numerator = value; } }
        public int Denominator { get { return denominator; } set { denominator = value; } }

        // Конструктор
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");

            this.numerator = numerator;
            this.denominator = denominator;
            Reduce();
        }

        // Метод для сокращения дроби
        public void Reduce()
        {
            int gcd = GCD(Math.Abs(Numerator), Denominator);
            Numerator /= gcd;
            Denominator /= gcd;

            // Если знаменатель отрицательный, переносим знак в числитель
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        // Метод для вычисления наибольшего общего делителя (Алгоритм Евклида)
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Перегрузка оператора сложения
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора вычитания
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора умножения
        public static Fraction operator *(Fraction a, Fraction b)
        {
            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        // Перегрузка оператора деления
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Нельзя делить на дробь с числителем равным нулю.");

            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;

            return new Fraction(numerator, denominator);
        }

        // Переопределение метода ToString для удобного вывода дроби
        public override string ToString()
        {
            if (Denominator == 1)
                return Numerator.ToString();
            else
                return $"{Numerator}/{Denominator}";
        }
    }
}