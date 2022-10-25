using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos
{
    public class CourseAddDto: FeaturesDtoBase<int>
    {
        public string Name { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Content { get; set; }
    }
}
