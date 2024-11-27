
using Microsoft.AspNetCore.Mvc;
using refund.Libs;


namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidatorsController : ControllerBase
    {
        private readonly IValidators _valid;
        public ValidatorsController(IValidators valid)
        {
            _valid=valid;
        }

        [HttpGet("RecordExists")]
        public async Task<IActionResult> RecordExists(string name)
        {
            return Ok(await _valid.RecordExistsValidate(name));
        }

        
        [HttpGet("SomepropertyEmpty")]
        public IActionResult SomepropertyEmpty(string name)
        {
            return Ok( _valid.PropertiesValidate(name));
        }
    }
}