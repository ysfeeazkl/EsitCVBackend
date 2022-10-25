using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos
{
    public class CurrentProjectAddDto: FeaturesDtoBase<int>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string ProjectUrl { get; set; }
    }
}
