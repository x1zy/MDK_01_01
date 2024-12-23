

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_3_1
{
    public class Fraction 
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        // Конструктор
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");

            // Обеспечиваем, чтобы знаменатель был положительным
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            Numerator = numerator;
            Denominator = denominator;
            Reduce(); // Сокращаем дробь при создании
        }

        // Метод для сокращения дроби
        public void Reduce()
        {
            int gcd = GCD(Math.Abs(Numerator), Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
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

            // Если знаменатель отрицательный, переносим знак в числитель
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

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

