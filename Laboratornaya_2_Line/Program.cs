namespace Laboratornaya_2_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1, y1, x2, y2;
            x1 = Convert.ToSingle(Console.ReadLine());
            x2 = Convert.ToSingle(Console.ReadLine());
            y1 = Convert.ToSingle(Console.ReadLine());
            y2 = Convert.ToSingle(Console.ReadLine());
            Line line = new Line(x1, x2, y1, y2);

            // x1++, так конструктор не изменяет значения полей
            Console.WriteLine("Расстояние");
            Console.WriteLine(line.GetLenght());
            Console.WriteLine("Изменённое поле");
            line.SetX1(line.GetX1() + 1);
            Console.WriteLine(line.GetX1());
        }
    }
}
