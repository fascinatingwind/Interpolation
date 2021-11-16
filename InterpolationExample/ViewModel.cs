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
            var data = entities.GammaRay;
            foreach(var item in data)
            {
                var depth = item.MD;
            }
        }
    }
}
