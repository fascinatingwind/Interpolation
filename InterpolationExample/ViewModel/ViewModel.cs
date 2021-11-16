using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpolationExample
{
    class ViewModel
    {
        public string File { get; set; }

        public void ExportFile()
        {
            var entities = new TestDataBaseEntities();
            var points = entities.GammaRay.ToList();
            var array = points
                .Skip(1)
                .Zip(points, (second, first) => new[] 
                { 
                    first, second 
                }).ToArray();

            var writer = new CsvWriter<GammaRay>();
            writer.Write(points, "test.csv");
        }
    }
}
