using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class JobApplication : EntityBase<int>, IEntity // iş ilanı sorularına verilen cevaplar gibi bişi yapılcak
    {
        public User User { get; set; }
        public int UserID { get; set; }

    }
}
