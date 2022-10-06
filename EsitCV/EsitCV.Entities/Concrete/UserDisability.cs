using EsitCV.Entities.Concrete.Disableds;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserDisability : EntityBase<int>, IEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Disability> Disabilities { get; set; }
    }
}
