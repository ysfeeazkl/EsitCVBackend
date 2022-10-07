using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class CompanyAndOperationClaim : EntityBase<int>, IEntity
    {
        public Company Company { get; set; }
        public int CompanyID { get; set; }
        public OperationClaim OperationClaim { get; set; }
        public int OperationClaimID { get; set; }
    }
}
