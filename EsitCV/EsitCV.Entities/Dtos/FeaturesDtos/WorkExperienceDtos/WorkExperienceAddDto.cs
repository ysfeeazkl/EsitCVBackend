using EsitCV.Entities.Abstract.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos
{
    public class WorkExperienceAddDto: FeaturesDtoBase<int>
    {
        public string CompanyName { get; set; }
        public int? CompanyID { get; set; }//çalıştığı şirketin eşitcv de profili varsa
        public string Content { get; set; }
        public string Title { get; set; }
        public string Activity { get; set; }
        public string Degree { get; set; }
        public string EducationCategory { get; set; } //örnek işletme
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool? Currently { get; set; }
    }
}
