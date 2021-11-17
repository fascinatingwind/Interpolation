using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample
{
    class CsvWriter<T>
    {
        IPropertyInterpolation interpol;
        public CsvWriter(IPropertyInterpolation interpolation)
        {
            interpol = interpolation;
        }

        public void Write(IEnumerable<T> list, string file)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>();
            properties.Add(interpol.GetXDimension());
            properties.AddRange(interpol.GetYDimensions());

            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (var item in list)
                {
                    string record = "";
                    foreach (var prop in properties)
                    {
                        record += prop.GetValue(item).ToString() + ";";
                    }
                    writer.WriteLine(record);
                }
            }
        }
    }
}
