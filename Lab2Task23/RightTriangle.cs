using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Task23
{
    public class RightTriangle
    {
        private double a;
        private double b;

        public RightTriangle()
        {
            a = 1;
            b = 1;
        }

        public RightTriangle(double a, double b)
        {
            this.a = Math.Max(a, b);
            this.b = Math.Min(a, b);
        }



        public double Area => (a * b) / 2;

        public override string ToString()
        {
            return $"Прямоугольный треугольник со сторонами (a={a}, b={b}, Площадь={Area})";
        }

        // 3 задание
        public static implicit operator double(RightTriangle rt)
        {
            return rt.Area;
        }

        public static explicit operator bool(RightTriangle rt)
        {
            return rt.a > 0 && rt.b > 0 && rt.a + rt.b > Math.Sqrt(Math.Pow(rt.a - rt.b, 2) * 4);
        }

        public static RightTriangle operator ++(RightTriangle rt)
        {
            return new RightTriangle(rt.a * 2, rt.b * 2);
        }

        public static RightTriangle operator --(RightTriangle rt)
        {
            return new RightTriangle(rt.a / 2, rt.b / 2);
        }

        public static bool operator <=(RightTriangle t1, RightTriangle t2)
        {
            return t1.Area <= t2.Area;
        }

        public static bool operator >=(RightTriangle t1, RightTriangle t2)
        {
            return t1.Area >= t2.Area;
        }

    }
}
