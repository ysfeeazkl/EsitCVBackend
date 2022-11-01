using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody] CourseAddDto courseAddDto)
        {
            var result = await _courseService.AddAsync(courseAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] CourseUpdateDto courseUpdateDto)
        {
            var result = await _courseService.UpdateAsync(courseUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _courseService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _courseService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var result = await _courseService.GetAllByProfileIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _courseService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _courseService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }



    }
}
