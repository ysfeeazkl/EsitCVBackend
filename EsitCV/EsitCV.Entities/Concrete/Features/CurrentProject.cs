using EsitCV.Entities.Abstract.Features;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete.Features
{
    public class CurrentProject : FeaturesBase<int>, IFeatures, IEntity
    {
        public string Name{ get; set; }
        public string Content{ get; set; }
        public string ProjectUrl{ get; set; }
    }
}
