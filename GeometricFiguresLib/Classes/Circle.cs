using GeometricFiguresLib.Extensions;
using System;

namespace GeometricFiguresLib.Classes
{
    public class Circle : Shape
    {
        /// <summary>
        /// Поле, которое указывает радиус нашего треугольника
        /// </summary>
        private double Radius { get; set; }

        public Circle() : this(0.0) { }

        public Circle(double radius) 
        {
            if (!this.IsValidCircle(radius))
                throw new ArgumentException(Constants.StringlValues.InvalidTriangleParametersRU);
            Radius = radius;   
        }

        /// <summary>
        /// Метод который позволяет получить площадь нашего круга, опираясь на его радиус
        /// </summary>
        /// <returns>Возвращает радиус фигуры</returns>
        public override double GetArea() => Constants.MathValues.MathPI * 2 * Radius;

        /// <summary>
        /// Метод который позволяет получить базовые значения фигуры
        /// </summary>
        /// <returns>Возвращает базовые значения фигуры</returns>
        public override string ToString() => $"Circle: {Radius}";
    }
}
