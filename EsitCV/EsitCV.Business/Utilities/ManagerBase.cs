using AutoMapper;
using EsitCV.Data.Concrete.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Utilities
{
    public class ManagerBase
    {
        public EsitCVContext DbContext { get; }
        public IMapper Mapper{ get; }

        public ManagerBase(IMapper mapper)
        {
            Mapper = mapper;
        }

        public ManagerBase(IMapper mapper, EsitCVContext context)
        {
            Mapper = mapper;
            DbContext = context;
        }
        public ManagerBase(EsitCVContext context)
        {
            DbContext = context;
        }
    }
}
