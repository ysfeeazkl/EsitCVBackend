using EsitCV.Shared.Utilities.Results.Abstract;
using EsitCV.Shared.Utilities.Results.ComplexTypes;

namespace EsitCV.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus, string message) : this(message)
        {
            ResultStatus = resultStatus;
        }
        public Result(string message)
        {
            Message = message;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
