using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Abstract.Features
{
    public class FeaturesUpdateDtoBase<T> where T : struct
    {
        public T ID { get; set; }
        public T UserProfileID { get; set; }
    }
}
