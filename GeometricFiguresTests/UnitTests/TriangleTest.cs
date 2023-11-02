using System;
using GeometricFiguresLib.Classes;
using GeometricFiguresLib.Extensions;
using GeometricFiguresTests.TestSettings;
using Xunit;

namespace GeometricFiguresTests
{
    /// <summary>
    /// Данный класс теста, содержит все тесты связанные с треугольниками
    /// </summary>
    public class TriangleTest
    {
        /// <summary>
        /// Метод-Тест для проверки метода IsValidTriangle. 
        /// Он должен в определенных ситуациях говорить нам о том,
        /// что по входящим параметрам может или нет построен треугольник
        /// </summary>
        [Fact]
        public void IsValidTriangle()
        {
            Assert.True(TriangleExtension.IsValidTriangle(null, 3.0, 4.0, 5.0));
            Assert.False(TriangleExtension.IsValidTriangle(null, 1.0, 1.0, 3.0));
            Assert.True(TriangleExtension.IsValidTriangle(null, 2.0, 2.0, 2.0));
            Assert.False(TriangleExtension.IsValidTriangle(null, -5, 3, 1));

            // Тут же проверим метод на исключение при попытке вставить не правильное количество аргументов
            Assert.Throws<ArgumentException>(() => TriangleExtension.IsValidTriangle(null, -5, 3, 1, 2, 3, 4));
            Assert.Throws<ArgumentException>(() => TriangleExtension.IsValidTriangle(null, 11, 0.3));
        }

        /// <summary>
        /// Метод-тест в котором мы проверим, что недопустимые значения треугольника выплевывают исключения
        /// </summary>
        [Fact]
        public void CantCreateTriangle()
        {
            Assert.Throws<ArgumentException>(() => new Triangle(-5, 3, 1));
            Assert.Throws<ArgumentException>(() => new Triangle(12, 1.1, -3));
        }

        /// <summary>
        /// Метод-тест в котором мы проверяем что метод IsRightTriangle отрабатывает верно
        /// </summary>
        [Fact]
        public void CheckIsRightTriangleMethod()
        {
            Assert.True(new Triangle(3.0, 4.0, 5.0).IsRightTriangle());
            Assert.False(new Triangle(3.0, 4.0, 6.0).IsRightTriangle());
            Assert.True(new Triangle(5.0, 3.0, 4.0).IsRightTriangle());
            Assert.False(new Triangle(2.0, 2.0, 2.0).IsRightTriangle());
        }

        /// <summary>
        /// Метод-тест в котором мы проверяем что наш метод расчета площади треугольника отрабатывает правильно
        /// </summary>
        [Fact]
        public void CheckCalculationAreaTriangleMethod()
        {
            Assert.Equal(6.0, new Triangle(3.0, 4.0, 5.0).GetArea());
            Assert.Equal(1.732, new Triangle(2.0, 2.0, 2.0).GetArea(), TriangleSettings.Tolerance);
        }
    }
}
