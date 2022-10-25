using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos
{
    public class OrganizationAddDto: FeaturesDtoBase<int>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool? Currently { get; set; }
        public string Content { get; set; }
        public string IssuingBodyName { get; set; }
    }
}
