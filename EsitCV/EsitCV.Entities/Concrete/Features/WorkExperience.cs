﻿using EsitCV.Entities.Abstract.Features;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete.Features
{
    public class WorkExperience : FeaturesBase<int>, IFeatures, IEntity
    {
        public string CompanyName { get; set; }
        public int? CompanyID{ get; set; }//çalıştığı şirketin eşitcv de profili varsa
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
