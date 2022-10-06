using EsitCV.Shared.Utilities.Results.ComplexTypes;

namespace EsitCV.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }// ResultStatus.Success // ResultStatus.Error
        public string Message { get; }
    }
}
