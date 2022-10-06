using EsitCV.Shared.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Results.Abstract;

namespace EsitCV.Shared.Utilities.Results.Concrete
{
    public class SuccessApiResult : ApiResult
    {
        public SuccessApiResult(IResult result, string href) : base(result.ResultStatus, result.Message, HttpStatusCode.OK, href)
        {
        }
    }
}

