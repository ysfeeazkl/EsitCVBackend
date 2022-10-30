using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasOfInterestController : ControllerBase
    {
        readonly IAreasOfInterestService _areasOfInterestService;
        public AreasOfInterestController(IAreasOfInterestService areasOfInterestService)
        {
            _areasOfInterestService = areasOfInterestService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(AreasOfInterestAddDto areasOfInterestAddDto)
        {
            var result = await _areasOfInterestService.AddAsync(areasOfInterestAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync(AreasOfInterestUpdateDto areasOfInterestUpdateDto)
        {
            var result = await _areasOfInterestService.UpdateAsync(areasOfInterestUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _areasOfInterestService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _areasOfInterestService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var result = await _areasOfInterestService.GetAllByProfileIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _areasOfInterestService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _areasOfInterestService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }


     
    }
}
