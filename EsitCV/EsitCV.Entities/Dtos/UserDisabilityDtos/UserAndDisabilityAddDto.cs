using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.UserDisabilityDtos
{
    public class UserAndDisabilityAddDto
    {
        public int UserID { get; set; }
        public int DisabilityID { get; set; }
        public int PercentageOfDisability { get; set; }
    }
}
