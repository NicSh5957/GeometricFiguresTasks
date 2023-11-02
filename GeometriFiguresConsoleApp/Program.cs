using GeometricFiguresLib.Classes;
using GeometricFiguresLib.Interfaces;
using System;
using System.Collections.Generic;

namespace GeometriFiguresConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
            {
                new Triangle(3.0, 4.0, 5.0),
                new Triangle(2.0, 2.0, 2.0),
                new Circle(2.0),
                new Circle(80)
            };
            foreach (var shape in shapes) 
            { 
                Console.WriteLine($"Объект: {shape}");
                ITriangle triangle = shape as ITriangle;
                if(triangle != null)
                {
                    var currentTriangle = (ITriangle)shape;
                    string triangleMessage = currentTriangle.IsRightTriangle() ? "Прямоугольный" : "Не прямоугольный";
                    Console.WriteLine(triangleMessage);
                }
            }
            Console.ReadLine();
        }
    }
}
