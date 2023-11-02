namespace GeometricFiguresLib.Interfaces
{
    public interface ITriangle
    {
        /// <summary>
        /// Метод который должен быть у любого треугольника, по нему мы ориентируемся, является ли треугольник прямоугольный
        /// </summary>
        /// <returns>Возвращает true, если треугольник прямоугольный, в противном случае false</returns>
        bool IsRightTriangle();
    }
}
