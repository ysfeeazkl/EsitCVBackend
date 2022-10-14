using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class Location:EntityBase<int>,IEntity
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }

    }
}
