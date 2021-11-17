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
            var points = entities.GammaRay.ToList()
                .Skip(1)
                .Zip(entities.GammaRay, (second, first) => new[]
                {
                    first, second
                }).ToList();
            
            var grInterpolate = new ObjectPropertyInterpolation<GammaRay>(new GammaRayPropertyInterpolation());
            var resultList = new List<GammaRay>();
            foreach (var point in points)
            {
                resultList.AddRange(grInterpolate.Interpolate(point.First(), point.Last(), 0.1));
            }
            var writer = new CsvWriter<GammaRay>();
            writer.Write(resultList, File);
        }
    }
}
