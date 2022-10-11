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
    public class UserPictureManager: ManagerBase, IUserPictureService
    {
        public UserPictureManager(EsitCVContext context, IMapper mapper) : base(mapper, context)
        {

        }
       
    }
}
