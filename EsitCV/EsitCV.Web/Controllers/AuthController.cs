using EsitCV.Business.Abstract;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAccessTokenByUserIdAsync(int userId, bool isRefresh)
        {
            var result = await _authService.CreateAccessTokenByUserIdAsync(userId, isRefresh);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAccessTokenByCompanyIdAsync(int companyId, bool isRefresh)
        {
            var result = await _authService.CreateAccessTokenByCompanyIdAsync(companyId, isRefresh);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CompanyRegisterAsync([FromBody] CompanyRegisterDto companyRegisterDto)
        {
            var result = await _authService.CompanyRegisterAsync(companyRegisterDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UserRegisterAsync([FromBody] UserRegisterDto userRegisterDto)
        {
            var result = await _authService.UserRegisterAsync(userRegisterDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CompanyLoginWithEmailAsync([FromBody] CompanyLoginWithEmailDto companyLoginWithEmailDto)
        {
            var result = await _authService.CompanyLoginWithEmailAsync(companyLoginWithEmailDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UserLoginWithEmailAsync([FromBody] UserLoginWithEmailDto userLoginWithEmailDto)
        {
            var result = await _authService.UserLoginWithEmailAsync(userLoginWithEmailDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        

    }
}
