using System;

namespace Zadanie_1
{
    public class HomeCat : Cat //дочерний класс
    {
        private string name; //кличка
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public HomeCat() : base()
        {
            name = "no name";
        }
        public HomeCat(int a, string n) : base(a)
        {
            name = n;
        }
        public override void View()
        {
            Console.WriteLine("Домашняя кошка " + Name + ", Возраст " + Age);
        }
    }
}
