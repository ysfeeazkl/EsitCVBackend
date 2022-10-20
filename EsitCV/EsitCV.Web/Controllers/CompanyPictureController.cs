using EsitCV.Business.Abstract;
using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyPictureController : ControllerBase
    {
        ICompanyPictureService _companyPictureService;
        public CompanyPictureController(ICompanyPictureService companyPictureService)
        {
            _companyPictureService = companyPictureService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromQuery] CompanyPictureAddDto companyPictureAddDto)
        {
            var result = await _companyPictureService.AddAsync(companyPictureAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromQuery] CompanyPictureUpdateDto companyPictureAddDto)
        {
            var result = await _companyPictureService.UpdateAsync(companyPictureAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _companyPictureService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByCompanyIdAsync(int id)
        {
            var result = await _companyPictureService.GetByCompanyIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByFileUrlAsync(string fileUrl)
        {
            var result = await _companyPictureService.DeleteByFileUrlAsync(fileUrl);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
