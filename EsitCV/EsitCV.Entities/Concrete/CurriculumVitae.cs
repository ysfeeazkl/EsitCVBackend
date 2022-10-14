using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class CurriculumVitae : EntityBase<int>, IEntity 
    {
        public string? FileUrl { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
