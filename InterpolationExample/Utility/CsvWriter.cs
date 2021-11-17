using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample
{
    class CsvWriter<T>
    {
        public void Write(IEnumerable<T> list, string file)
        {
            var typeInfo = typeof(T);
            var properties = typeInfo.GetProperties();
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
