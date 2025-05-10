using System;

namespace Lab2Task23
{
    public class RightTriangle
    {
        private double _a;
        private double _b;

        public RightTriangle()
        {
            _a = 1;
            _b = 1;
        }

        public RightTriangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Длины сторон должны быть положительными.");

            _a = Math.Max(a, b);
            _b = Math.Min(a, b);
        }

        public double Area => (_a * _b) / 2;

        public override string ToString()
        {
            return $"Прямоугольный треугольник со сторонами (a={_a}, b={_b}), площадь={Area:F2}";
        }

        public static implicit operator double(RightTriangle rt) => rt.Area;

        public static explicit operator bool(RightTriangle rt)
            => rt._a > 0 && rt._b > 0 && rt._a + rt._b > Math.Sqrt(Math.Pow(rt._a - rt._b, 2) * 4);

        public static RightTriangle operator ++(RightTriangle rt)
            => new RightTriangle(rt._a * 2, rt._b * 2);

        public static RightTriangle operator --(RightTriangle rt)
            => new RightTriangle(rt._a / 2, rt._b / 2);

        public static bool operator <=(RightTriangle t1, RightTriangle t2)
            => t1.Area <= t2.Area;

        public static bool operator >=(RightTriangle t1, RightTriangle t2)
            => t1.Area >= t2.Area;
    }
}
