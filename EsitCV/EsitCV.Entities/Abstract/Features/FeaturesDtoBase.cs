using EsitCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Abstract.Features
{
    public class FeaturesDtoBase<T> where T : struct
    {
        public T UserProfileID { get; set; }
    }
}
