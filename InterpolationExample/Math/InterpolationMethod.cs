using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample
{
    static class InterpolatioMethod
    {
        public static double InterpolateDouble(Point point1, Point point2, double x)
        {
            return point1.Y + (x - point1.X) * (point2.Y - point1.Y)/(point2.X - point1.X);
        }
    }
}
