using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserAndOperationClaim : EntityBase<int>, IEntity
    {
        public User User { get; set; }
        public int UserID { get; set; }
        public OperationClaim OperationClaim { get; set; }
        public int OperationClaimID { get; set; }
    }
}
