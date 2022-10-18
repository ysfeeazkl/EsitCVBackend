using EsitCV.Entities.Concrete.Disableds;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserAndDisability : EntityBase<int>, IEntity
    {
        public User User { get; set; }
        public int UserID { get; set; }
        public Disability Disability { get; set; }
        public int DisabilityID { get; set; }
        public int PercentageOfDisability { get; set; }

    }
}
