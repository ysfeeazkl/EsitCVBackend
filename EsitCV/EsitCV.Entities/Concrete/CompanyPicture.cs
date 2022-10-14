using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class CompanyPicture:EntityBase<int>,IEntity
    {
        public string? FileName { get; set; }
        public string? FileUrl { get; set; }
        public Company Company{ get; set; }
        public int CompanyID { get; set; }
    }
}
