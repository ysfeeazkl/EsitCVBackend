using EsitCV.Entities.Abstract.Features;
using EsitCV.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos
{
    public class LanguageAddDto: FeaturesDtoBase<int>
    {
        public string Name { get; set; }
        public LanguageLevel Level { get; set; }
    }
}
