using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample.Math
{
    static class DoubleCompare
    {
        static double eps = 0.000001;
        public static bool IsEqual(double a, double b)
        {
            return System.Math.Abs(a - b) <= (System.Math.Max(a, b) * eps);
        }

        public static bool GreaterThan(double a, double b)
        {
            return (a - b) > (System.Math.Max(a, b) * eps);
        }

        public static bool definitelyLessThan(double a, double b)
        {
            return (b - a) > (System.Math.Max(a, b) * eps);
        }
    }
}
