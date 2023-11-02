using GeometricFiguresLib.Classes;

namespace GeometricFiguresLib.Extensions
{
    public static class CircleExtension
    {
        /// <summary>
        /// Метод для проверки валидности круга. В нашем случае проверка пока простая
        /// Мы просто проверяем на то, что бы значение радиуса было положительным
        /// </summary>
        /// <param name="radius">Параметр радиуса</param>
        /// <returns>Возвращает true если круг допустим</returns>
        public static bool IsValidCircle(this Circle circle, double radius) => radius >= 0;
    }
}
