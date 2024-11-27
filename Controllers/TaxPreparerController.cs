
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using refund.DTOs;
using refund.Services;
using Serilog;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxPreparerController : ControllerBase
    {
        private readonly ITaxPreparer _preparer;
        public TaxPreparerController(ITaxPreparer preparer)
        {
            _preparer = preparer;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TaxPreparerDto preparerDto)
        {
            if (preparerDto is null)
            {
                Log.Error("One or more properties are invalid");
                return NotFound();
            }

            return Ok(await _preparer.Create(preparerDto));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _preparer.GetAll());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TaxPreparerDto preparerDto)
        {

            return Ok(await _preparer.Update(preparerDto));
        }
          [AllowAnonymous]
        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(int preparerId)
        {

            return Ok(await _preparer.GetImagebyTaxPreparerId(preparerId));
        }
          [AllowAnonymous]
        [HttpGet("ValidateZipCode")]
        public async Task<IActionResult>ValidateZipCode(string username)
        {
            return Ok(await _preparer.ValidateZipCode(username));
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int TaxPreparerId)
        {

            return Ok(await _preparer.Delete(TaxPreparerId));
        }

        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetbyId(int TaxPreparerId)
        {

            return Ok(await _preparer.GetbyId(TaxPreparerId));
        }

        [AllowAnonymous]
        [HttpGet("Validate")]
        public async Task<IActionResult> Validate(string username)
        {

            return Ok(await _preparer.Check(username));
        }
        [AllowAnonymous]
        [HttpGet("GetDataPreparer")]
       
        public async Task<IActionResult> GetDataPreparer(string username)
        {
            return Ok(await _preparer.GetDataPreparer(username));
        }

    }
}