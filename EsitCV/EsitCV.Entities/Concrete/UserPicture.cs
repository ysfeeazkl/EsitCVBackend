using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserPicture: EntityBase<int>, IEntity
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
