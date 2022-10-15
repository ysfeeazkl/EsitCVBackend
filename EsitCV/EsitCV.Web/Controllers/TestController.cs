using EsitCV.Business.AbstractUtilities;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IAwsStorageService _awsStorageService;
        public TestController(IAwsStorageService awsStorageService)
        {
            _awsStorageService = awsStorageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> uploadCv(IFormFile file)
        {
            var result = await _awsStorageService.UploadCVFileAsync(file);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> uploadFile(IFormFile file)
        {
            var result = await _awsStorageService.UploadFileAsync(file);
            var url = _awsStorageService.GetFileUrl((string)result.Data);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(url);
            return BadRequest(result);
        }
    }
}
