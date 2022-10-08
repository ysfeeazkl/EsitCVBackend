using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserToken:IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User User{ get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
