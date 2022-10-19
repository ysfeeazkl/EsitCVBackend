using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.UserDisabilityDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAndDisabilityController : ControllerBase
    {
        IUserAndDisabilityService _userAndDisabilityService;
        public UserAndDisabilityController(IUserAndDisabilityService userAndDisabilityService)
        {
            _userAndDisabilityService = userAndDisabilityService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(UserAndDisabilityAddDto userAndDisabilityAddDto)
        {
            var result = await _userAndDisabilityService.AddAsync(userAndDisabilityAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _userAndDisabilityService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByUserIdAsync(int userID, bool inculudeDisability)
        {
            var result = await _userAndDisabilityService.GetAllByUserIdAsync(userID, inculudeDisability);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllByDisabilityIdAsync(int disabilityID, bool inculudeUser)
        {
            var result = await _userAndDisabilityService.GetAllByDisabilityIdAsync(disabilityID, inculudeUser);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByUserIdAndDisabilityIdAsync(int userID, int disabilityID)
        {
            var result = await _userAndDisabilityService.DeleteByUserIdAndDisabilityIdAsync(userID, disabilityID);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
