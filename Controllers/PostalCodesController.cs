using Microsoft.AspNetCore.Mvc;
using refund.Services;

namespace refund.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostalCodesController : ControllerBase
    {
        private readonly IPostalCode _postal;
        public PostalCodesController(IPostalCode postal)
        {
            _postal = postal;
        }
        [HttpGet("StateList")]
        public async Task<IActionResult> StateList()
        {
            return Ok(await _postal.StateList());
        }

        [HttpGet("ZipCodeList")]
        public async Task<IActionResult> ZipCodeList(string? state = "", string? city = "")
        {
            return Ok(await _postal.ZipCodeList(state, city));
        }


        [HttpGet("CityList")]
        public async Task<IActionResult> CityList(string? state = "")
        {
            return Ok(await _postal.CityList(state));
        }

        [HttpGet("StateList_CityList")]
        public async Task<IActionResult> StateList_CityList(string? zipcode = "")
        {
            return Ok(await _postal.StateList_CityList(zipcode));
        }



    }
}