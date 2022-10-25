using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.HobbieDtos
{
    public class HobbieAddDto: FeaturesDtoBase<int>
    {
        public string Name { get; set; }
    }
}
