using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class OperationClaim : EntityBase<int>, IEntity
    {
        public string Name { get; set; }

    }
}
