using GeometricFiguresLib.Interfaces;
using GeometricFiguresLib.Extensions;
using System;

namespace GeometricFiguresLib.Classes
{
    public class Triangle : Shape, ITriangle
    {
        // Поля для обозначения сторон треугольника
        #region стороны нашего треугольника
        public double A { get; set; }
        public double B { get; set; }  
        public double C { get; set; }
        #endregion

        public Triangle(double a, double b, double c)
        { 
            if (!this.IsValidTriangle(a, b, c))
                throw new ArgumentException(Constants.StringlValues.InvalidTriangleParametersRU);
            A = a;
            B = b;
            C = c;
        }   

        public override double GetArea()
        {
            // Если видим, что есть деление на 2, то заменяем его умножением на 0.5.
            // Это дает большую оптимизацию на уровне CLR, т.к. под капотом выполняется меньше операций
            // Ниже, переменную s, можно было заменить на: (A + B + C) / 2;
            double s = (A + B + C) * 0.5;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }


        /// <summary>
        /// Метод указывающий на то, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>Возвращает true, если прямоугольник треугольный, в противном случае false</returns>
        public bool IsRightTriangle()
        {
            double[] sides = { A, B, C };
            Array.Sort(sides);
            return sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2];
        }

        /// <summary>
        /// Метод который позволяет получить базовые значения фигуры
        /// </summary>
        /// <returns>Возвращает базовые значения фигуры</returns>
        public override string ToString() => $"Triangle with area: {GetArea()}";
    }
}
