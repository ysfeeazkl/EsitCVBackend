using EsitCV.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Abstract
{
    public interface IAdminService
    {
        public Task<IDataResult> LoginWithPhone { get; set; }
        public Task<IDataResult> LoginWithEmail { get; set; }
    }
}
