using GeometricFiguresLib.Classes;
using GeometricFiguresLib.Extensions;
using Xunit;

namespace GeometricFiguresTests.UnitTests
{
    /// <summary>
    /// Данный класс теста, содержит все тесты связанные с кругом
    /// </summary>
    public class CircleTests
    {
        /// <summary>
        /// Метод-Тест для проверки метода IsValidCircle. 
        /// Он должен в определенных ситуациях говорить нам о том,
        /// что по входящим параметрам может или нет построен круг
        /// </summary>
        [Fact]
        public void IsValidCircle()
        {
            Assert.True(CircleExtension.IsValidCircle(null, 1));
            Assert.False(CircleExtension.IsValidCircle(null, -1));
            Assert.True(CircleExtension.IsValidCircle(null, 2));
            Assert.False(CircleExtension.IsValidCircle(null, -2));
        }

        /// <summary>
        /// Метод-тест в котором мы проверяем что наш метод расчета площади круга отрабатывает правильно
        /// </summary>
        [Fact]
        public void CheckCalculationAreaCircleMethod()
        {
            Assert.Equal(0, new Circle(0).GetArea());
        }
    }
}
