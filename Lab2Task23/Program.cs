using Lab2Task23;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Программа для работы с прямоугольным треугольником");
        Console.WriteLine("Для выхода нажмите Ctrl+C\n");

        var defaultTriangle = new RightTriangle();
        Console.WriteLine($"Объект RightTriangle создан с помощью конструктора по умолчанию: {defaultTriangle}");

        try
        {
            while (true)
            {
                ProcessTriangle();
                Console.WriteLine(new string('-', 40) + "\n");
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nПрограмма завершена.");
        }
    }


    private static void ProcessTriangle()
    {
        Console.Write("Введите длину первого катета (a): ");
        if (!IsValidInput(out double a))
            return;

        Console.Write("Введите длину второго катета (b): ");
        if (!IsValidInput(out double b))
            return;

        try
        {
            var triangle = new RightTriangle(a, b);
            Console.WriteLine($"\nСоздан новый треугольник: {triangle}");

            DisplayActions(triangle);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }


    private static void DisplayActions(RightTriangle triangle)
    {
        Console.WriteLine("\nДействие 1: Вычисление и вывод площади");
        Console.WriteLine($"Площадь треугольника: {triangle.Area:F2}");
        Console.WriteLine($"Площадь в виде строки: {triangle}");

        var doubledTriangle = ++triangle;
        Console.WriteLine("\nДействие 2: Увеличение сторон в два раза");
        Console.WriteLine($"Увеличенный треугольник: {doubledTriangle}");
        Console.WriteLine($"Новая площадь: {doubledTriangle.Area:F2}");

        const double c = 13;
        bool isLarger = triangle >= new RightTriangle(c, c);
        Console.WriteLine("\nДействие 3: Сравнение с треугольником со сторонами ({0}, {0})", c);
        Console.WriteLine($"Треугольник {triangle} {(isLarger ? "больше" : "меньше")} или равен");

        Console.WriteLine("\nДействие 4: Приведение к типу double и bool");
        Console.WriteLine($"Неявное приведение к double: {(double)triangle:F2}");
        Console.WriteLine($"Явное приведение к bool: {(bool)triangle}");
    }

    private static bool IsValidInput(out double value)
    {
        value = 0;
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
            return false;

        if (!double.TryParse(input, out value) || value <= 0)
        {
            Console.WriteLine("Ошибка: введите положительное число.");
            return false;
        }

        return true;
    }
}


