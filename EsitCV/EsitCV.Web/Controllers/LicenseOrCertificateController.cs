using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseOrCertificateController : ControllerBase
    {
        readonly ILicenseOrCertificateService _licenseOrCertificateService;
        public LicenseOrCertificateController(ILicenseOrCertificateService licenseOrCertificateService)
        {
            _licenseOrCertificateService = licenseOrCertificateService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync(LicenseOrCertificateAddDto licenseOrCertificateAddDto)
        {
            var result = await _licenseOrCertificateService.AddAsync(licenseOrCertificateAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync(LicenseOrCertificateUpdateDto licenseOrCertificateUpdateDto)
        {
            var result = await _licenseOrCertificateService.UpdateAsync(licenseOrCertificateUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _licenseOrCertificateService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _licenseOrCertificateService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllByProfileIdAsync(int id)
        {
            var result = await _licenseOrCertificateService.GetAllByProfileIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _licenseOrCertificateService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _licenseOrCertificateService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
