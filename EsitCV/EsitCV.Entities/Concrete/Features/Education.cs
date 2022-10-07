using EsitCV.Entities.Abstract.Features;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete.Features
{
    public class Education : FeaturesBase<int>, IFeatures, IEntity
    {
        public string InstitutionName { get; set; }
        public string Content { get; set; }
        public string Activity { get; set; }
        public string Degree { get; set; }
        public string EducationCategory { get; set; } //örnek işletme
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

    }
}
