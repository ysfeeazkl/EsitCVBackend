using EsitCV.Business.Abstract;
using EsitCV.Entities.Dtos.UserPictureDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPictureController : ControllerBase
    {
        IUserPictureService _userPictureService;
        public UserPictureController(IUserPictureService userPictureService)
        {
            _userPictureService = userPictureService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(UserPictureAddDto userPictureAddDto)
        {
            var result = await _userPictureService.AddAsync(userPictureAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync(UserPictureUpdateDto userPictureAddDto)
        {
            var result = await _userPictureService.UpdateAsync(userPictureAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userPictureService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result); 
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByUserIdAsync(int id)
        {
            var result = await _userPictureService.GetByUserIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByFileUrlAsync(string fileUrl)
        {
            var result = await _userPictureService.DeleteByFileUrlAsync(fileUrl);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}



