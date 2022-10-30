using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentProjectController : ControllerBase
    {
        readonly ICurrentProjectService _currentProjectService;
        public CurrentProjectController(ICurrentProjectService currentProjectService)
        {
            _currentProjectService = currentProjectService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(CurrentProjectAddDto currentProjectAddDto)
        {
            var result = await _currentProjectService.AddAsync(currentProjectAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync(CurrentProjectUpdateDto currentProjectUpdateDto)
        {
            var result = await _currentProjectService.UpdateAsync(currentProjectUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _currentProjectService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _currentProjectService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var result = await _currentProjectService.GetAllByProfileIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _currentProjectService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _currentProjectService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
