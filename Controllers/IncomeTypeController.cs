
using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeTypeController : ControllerBase
    {

        private readonly IIncometype _incometype;
        private readonly ILogger<IncomeTypeController> _logger;
        public IncomeTypeController(IIncometype incometype, ILogger<IncomeTypeController> logger)
        {
            _incometype=incometype;
            _logger=logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] IncomeTypeDto income)
        {
            if (income is null)
            {
                _logger.LogError("One or more properties are invalid");
                return NotFound();
            }

            return Ok(await _incometype.Create(income));
        }
         [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _incometype.GetAll());
        }
   
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] IncomeTypeDto income)
        {
            
            return Ok(await _incometype.Update(income));
        }

            [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int IncomeTypeId)
        {
            
            return Ok(await _incometype.Delete(IncomeTypeId));
        }

             [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int IncomeTypeId)
        {
            
            return Ok(await _incometype.GetbyId(IncomeTypeId));
        }
    }
}