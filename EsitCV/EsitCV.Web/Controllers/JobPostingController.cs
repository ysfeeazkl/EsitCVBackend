using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.JobPostingDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostingController : ControllerBase
    {
        IJobPosingService _jobPosingService;
        public JobPostingController(IJobPosingService jobPosingService)
        {
            _jobPosingService = jobPosingService;
        }
        

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody] JobPostingAddDto jobPostingAddDto)
        {
            var result = await _jobPosingService.AddAsync(jobPostingAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] JobPostingUpdateDto jobPostingUpdateDto)
        {
            var result = await _jobPosingService.UpdateAsync(jobPostingUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _jobPosingService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _jobPosingService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByCompanyIdAsync(int id)
        {
            var result = await _jobPosingService.GetAllByCompanyIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _jobPosingService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _jobPosingService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
