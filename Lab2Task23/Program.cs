using Lab2Task23;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Программа для работы с прямоугольным треугольником");

        var defaultTriangle = new RightTriangle();
        Console.WriteLine($"Объект RightTriangle создан с помощью конструктора по умолчанию: {defaultTriangle}");

        while (true)
        {
            Console.Write("Введите длину первого катета (a): ");
            if (!GetValidInput(out double a))
                continue;

            Console.Write("Введите длину второго катета (b): ");
            if (!GetValidInput(out double b))
                continue;

            try
            {
                var triangle = new RightTriangle(a, b);
                Console.WriteLine($"Создан новый треугольник: {triangle}");

                // Действие 1: Вывод площади
                Console.WriteLine("\nДействие 1: Вычисление и вывод площади");
                Console.WriteLine($"Площадь треугольника: {triangle.Area}");
                Console.WriteLine($"Площадь в виде строки: {triangle}");

                // Действие 2: Увеличение сторон
                var doubledTriangle = ++triangle;
                Console.WriteLine("\nДействие 2: Увеличение сторон в два раза");
                Console.WriteLine($"Увеличенный треугольник: {doubledTriangle}");
                Console.WriteLine($"Новая площадь: {doubledTriangle.Area}");

                // Действие 3: Сравнение с другим треугольником
                double c = 13; // Предположим, это третья сторона другого треугольника
                bool isLarger = triangle >= new RightTriangle(c, c);
                Console.WriteLine($"\nДействие 3: Сравнение с треугольником со сторонами ({c}, {c})");
                Console.WriteLine($"Треугольник {triangle} {(isLarger ? "больше" : "меньше")} или равен");

                // Действие 4: Приведение к типу double и bool
                Console.WriteLine("\nДействие 4: Приведение к типу double и bool");
                Console.WriteLine($"Приведение к double: {Convert.ToDouble(triangle)}");
                Console.WriteLine($"Приведение к bool: {Convert.ToBoolean(triangle)}");


                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка при создании треугольника: {ex.Message}");
            }
        }

    }

    static bool GetValidInput(out double value)
    {
        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (double.TryParse(input, out value))
            {
                if (value <= 0)
                    Console.WriteLine("Длина стороны должна быть положительной.");
                else
                    return true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            }
        }
    }
}


