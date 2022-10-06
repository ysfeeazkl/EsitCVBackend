using EsitCV.Entities.Concrete.Disableds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserDisability
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Disability> Disabilities { get; set; }
    }
}
