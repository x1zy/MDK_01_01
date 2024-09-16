using System;
namespace Zadanie_1
{
    public abstract class Cat //базовый класс 
    {
        private int age; //возраст
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0) age = value;
                else age = 0;
            }
        }

        public abstract void View(); //абстрактный метод

        public Cat()
        { age = 0; }
        public Cat(int a)
        {
            if (a > 0) age = a; else age = 0;
        }
    }
}
