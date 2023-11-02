namespace GeometricFiguresTests.TestSettings
{
    /// <summary>
    /// Класс, в котором мы указываем различные параметры для наших тестов
    /// </summary>
    internal class CircleSettings
    {
        /// <summary>
        /// Свойство которое говорит на сколько у нас допустима погрешность в наших тестах
        /// </summary>
        public static double Tolerance { get; set; } = 0.001;

        public static double CircleRound { get; set; } = 2;
    }
}
