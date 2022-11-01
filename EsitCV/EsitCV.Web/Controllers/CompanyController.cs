using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.CompanyDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] CompanyUpdateDto companyUpdateDto)
        {
            var result = await _companyService.UpdateAsync(companyUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _companyService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _companyService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _companyService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _companyService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
