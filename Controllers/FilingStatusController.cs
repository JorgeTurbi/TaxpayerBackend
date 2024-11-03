using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;
using Serilog;

namespace refund.Controllers
{
     [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FilingStatusController : ControllerBase
    {
        
        private readonly IFilingStatus _status;
       
        public FilingStatusController(IFilingStatus status)
        {
            _status=status;
          
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] FilingStatusDto statusDto)
        {
            if (statusDto is null)
            {
                Log.Error("One or more properties are invalid");
                return NotFound();
            }

            return Ok(await _status.Create(statusDto));
        }
          [AllowAnonymous]
         [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _status.GetAll());
        }
   
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] FilingStatusDto statusDto)
        {
            
            return Ok(await _status.Update(statusDto));
        }

            [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int FilingstatusId)
        {
            
            return Ok(await _status.Delete(FilingstatusId));
        }

             [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int FilingstatusId)
        {
            
            return Ok(await _status.GetbyId(FilingstatusId));
        }
    }
}