using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;

namespace EsitCV.Business.Concrete
{
    public class AreasOfInterestManager: ManagerBase, IAreasOfInterestService
    {
        public AreasOfInterestManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {
                
        }
    }
}
