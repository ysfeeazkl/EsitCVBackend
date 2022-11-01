using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.EducationDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody] EducationAddDto educationAddDto)
        {
            var result = await _educationService.AddAsync(educationAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] EducationUpdateDto educationUpdateDto)
        {
            var result = await _educationService.UpdateAsync(educationUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _educationService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _educationService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var result = await _educationService.GetAllByProfileIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _educationService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _educationService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
