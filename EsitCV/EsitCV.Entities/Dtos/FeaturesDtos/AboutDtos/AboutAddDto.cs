using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos
{
    public class AboutAddDto: FeaturesDtoBase<int>
    {
        public string Content { get; set; }
    }
}
