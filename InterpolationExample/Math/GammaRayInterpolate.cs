using InterpolationExample.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample
{
    interface IPropertyInterpolation
    {
        PropertyInfo GetXDimension();
        List<PropertyInfo> GetYDimensions();
    }

    class GammaRayPropertyInterpolation : IPropertyInterpolation
    {
        public List<PropertyInfo> GetYDimensions()
        {
            return new List<PropertyInfo> {
                typeof(GammaRay).GetProperty("GRBX"),
            typeof(GammaRay).GetProperty("datastamp")};
        }

        public PropertyInfo GetXDimension()
        {
            return typeof(GammaRay).GetProperty("MD");
        }
    }


    class ObjectPropertyInterpolation<T> where T : new()
    {
        IPropertyInterpolation propInterp;
        public ObjectPropertyInterpolation(IPropertyInterpolation propertyInterpolation)
        {
            propInterp = propertyInterpolation;
        }
        public List<T> Interpolate(T left, T right, double step)
        {
            var xProp = propInterp.GetXDimension();
            var yProp = propInterp.GetYDimensions();
            var xLeft = Convert.ToDouble(xProp.GetValue(left));
            var xRight = Convert.ToDouble(xProp.GetValue(right));
            if (DoubleCompare.IsEqual(xLeft, xRight))
                return new List<T>();

            var result = new List<T>();
            var item = new T();
            foreach (var prop in yProp)
            {
                xProp.SetValue(item, xLeft + step);
                if (prop.PropertyType == typeof(double))
                {
                    prop.SetValue(item,
                        InterpolatioMethod.InterpolateDouble(
                        new Point { X = xLeft, Y = Convert.ToDouble(prop.GetValue(left)) },
                        new Point { X = xRight, Y = Convert.ToDouble(prop.GetValue(right)) }, step));
                }
                
                if (prop.PropertyType == typeof(System.DateTime))
                {
                    prop.SetValue(item, DateTime.FromOADate(
                        InterpolatioMethod.InterpolateDouble(
                            new Point { X = xLeft, Y = Convert.ToDateTime(prop.GetValue(left)).ToOADate() },
                            new Point { X = xRight, Y = Convert.ToDateTime(prop.GetValue(right)).ToOADate() }, step)));
                }
            }
            result.Add(item);
            result.AddRange(Interpolate(item, right, step));
            return result;
        }
    }
}
