using GeometricFiguresLib.Classes;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace GeometricFiguresLib.Extensions
{
    public static class TriangleExtension
    {
        public static bool IsValidTriangle(this Triangle triangle, double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public static bool IsValidTriangle(this Triangle triangle, params double[] sides)
        {
            if (sides.Length != 3)
                throw new ArgumentException(Constants.StringlValues.InvalidTriangleCountParametersRU);
            return IsValidTriangle(triangle, sides[0], sides[1], sides[2]);
        }
    }
}
