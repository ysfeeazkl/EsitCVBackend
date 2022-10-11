using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Business.Abstract;
using EsitCV.Business.Utilities;
using EsitCV.Data.Concrete.Context;
using AutoMapper;

namespace EsitCV.Business.Concrete
{
    public class LanguageManager : ManagerBase, ILanguageService
    {
        public LanguageManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }
    }
}
