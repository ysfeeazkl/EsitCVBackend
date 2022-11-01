using EsitCV.Business.Abstract;
using EsitCV.Entities.ComplexTypes;
using EsitCV.Entities.Dtos.AnswerDtos;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EsitCV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAsync([FromBody] AnswerAddDto answerAddDto)
        {
            var result = await _answerService.AddAsync(answerAddDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAsync([FromBody] AnswerUpdateDto answerUpdateDto)
        {
            var result = await _answerService.UpdateAsync(answerUpdateDto);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync(bool? isDeleted, bool isAscending, int currentPage, int pageSize, OrderBy orderBy)
        {
            var result = await _answerService.GetAllAsync(isDeleted, isAscending, currentPage, pageSize, orderBy);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _answerService.GetByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByQuestionIdAsync(int id)
        {
            var result = await _answerService.GetByQuestionIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByUserIdAsync(int id)
        {
            var result = await _answerService.GetByUserIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var result = await _answerService.DeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> HardDeleteByIdAsync(int id)
        {
            var result = await _answerService.HardDeleteByIdAsync(id);
            if (result.ResultStatus == ResultStatus.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
