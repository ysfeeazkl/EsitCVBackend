using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using AutoMapper;
using EsitCV.Data.Concrete.Context;

namespace EsitCV.Business.Concrete
{
    public class JobApplicationAndJobPostingManager: ManagerBase, IJobApplicationAndJobPostingService
    {
        public JobApplicationAndJobPostingManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }
    }
}
