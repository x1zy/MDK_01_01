using System;

namespace Zadanie_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // создаем список объектов класса HomeCat
            List<HomeCat> homeCats = new();

            // добавляем объекты в список
            homeCats.Add(new HomeCat(1, "Фурка"));
            homeCats.Add(new HomeCat(2, "Фиса"));
            homeCats.Add(new HomeCat(-10, "Барсик"));

            // вывод информации о каждом объекте в списке
            foreach (HomeCat cat in homeCats)
            {
                cat.View();
            }

            Console.ReadLine();
        }
    }
}
