using EsitCV.Shared.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Shared.Utilities.Results.Concrete
{
    public class SuccessDataApiResult : ApiResult
    {
        public SuccessDataApiResult(IDataResult dataResult, string href) : base(dataResult.ResultStatus, dataResult.Message, HttpStatusCode.OK, href)
        {
            Data = dataResult.Data;
        }
        public Object Data { get; set; }
    }
}

